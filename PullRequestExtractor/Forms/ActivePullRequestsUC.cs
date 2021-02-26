using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Interfaces.IActivePRView;
using PullRequestExtractor.Presenters;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PullRequestExtractor.Forms
{
    public partial class ActivePullRequestsUC : UserControl, IActivePRView
    {
        public event GetActivePullRequestsDelegate GetActivePullRequests;
        public event OpenPullRequestDelegate OpenPullRequest;

        private CancellationTokenSource _cancellationTokenSource;

        private readonly int _pollingInterval;
        private readonly string _project;
        private readonly string _org;

        public ActivePullRequestsUC(IAzureAPI api, CancellationTokenSource cancellationToken)
        {
            InitializeComponent();
            new ActivePullRequestPresenter(this, api);

            if (!api.Settings.TryGetAppSetting("ActiveProject", out _project))
                throw new InvalidOperationException("Could not find a valid personal access token for Azure DevOps");

            if (!api.Settings.TryGetAppSetting("Org", out _org))
                throw new InvalidOperationException("Could not find an Organisation for Azure DevOps");

            string pollingInterval;
            if (!api.Settings.TryGetAppSetting("PollingInterval", out pollingInterval))
                throw new InvalidOperationException("Could not find a valid polling interval");

            if (!int.TryParse(pollingInterval, out _pollingInterval))
                throw new InvalidOperationException("Could not parse the polling interval");

            _cancellationTokenSource = cancellationToken;
        }


        private async void ActivePullRequestsUC_Load(object sender, EventArgs e)
        {
            try
            {
                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    await GetActivePRs(sender, e);
                    await Task.Delay(_pollingInterval, _cancellationTokenSource.Token);
                }
            }
            catch (TaskCanceledException) { /* swallow - app is closing */ }
            catch (Exception ex)
            {
                // some other error happened
                MessageBox.Show($"{ex.Message}\n{ex.InnerException.Message}\n\n. Check the Windows Event Viewer for more information.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private async void btnGetActivePRs_Click(object sender, EventArgs e)
        {
            await GetActivePRs(sender, e);
        }

        private async Task GetActivePRs(object sender, EventArgs e)
        {
            DataTable prs = await GetActivePullRequests?.Invoke();

            dgvPRs.DataSource = null;
            dgvPRs.AutoGenerateColumns = true;
            dgvPRs.Refresh();

            var dgvBindingSource = new BindingSource(prs, null);
            dgvPRs.DataSource = dgvBindingSource;
            dgvPRs.Refresh();
        }

        private void dgvPRs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvPRs.Rows[e.RowIndex];
            string codeReviewId = row.Cells["CodeReviewId"]?.Value.ToString();
            string repo = row.Cells["Repo"]?.Value.ToString();

            OpenPullRequest(codeReviewId, repo, _org, _project);
        }
    }
}
