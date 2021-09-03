using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Presenters;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PullRequestExtractor.Forms
{
    public partial class ReposUC : UserControl, IRepositoriesView
    {
        public event GetRepositoryNamesDelegate GetRepositoryNames;
        public event DisplayRepositoryBranchesDelegate GetRepositoryBranches;

        private readonly IAzureAPI _api;
        private readonly CancellationTokenSource _cancellationToken;
        private readonly Action<bool> _setConnectivityError;

        public ReposUC(IAzureAPI api, CancellationTokenSource cancellationToken, Action<bool> setConnectivityError)
        {
            InitializeComponent();
            new RepositoriesPresenter(this, api, setConnectivityError);

            _api = api;
            _cancellationToken = cancellationToken;
            _setConnectivityError = setConnectivityError;

            adgvRepos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void ReposUC_Load(object sender, EventArgs e)
        {
            DataTable repos = null;

            try
            {
                repos = await GetRepositoryNames?.Invoke();

                adgvRepos.DataSource = null;
                adgvRepos.AutoGenerateColumns = true;
                adgvRepos.Refresh();

                adgvRepos.DataSource = repos;
                adgvRepos.Refresh();
            }
            catch (TaskCanceledException) { /* swallow - app is closing */ }
            catch (Exception ex)
            {
                // some other error happened
                MessageBox.Show($"{ex.Message}\n{ex.InnerException.Message}\n Check the Windows Event Viewer for more information.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _setConnectivityError(false);
            };
        }

        private void btnRefreshRepos_Click(object sender, EventArgs e)
        {
            ReposUC_Load(sender, e);
        }

        private void adgvRepos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = adgvRepos.Rows[e.RowIndex];
            Guid repoId = Guid.Parse(row.Cells["RepositoryID"]?.Value.ToString());
            Guid projectId = Guid.Parse(row.Cells["ProjectID"]?.Value.ToString());

            GetRepositoryBranches(repoId, projectId);
        }
    }
}