using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Presenters;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PullRequestExtractor.Forms
{
    public partial class SubscribedProjectsForm : Form, IGetSubscribedProjects
    {
        public event GetProjectsDelegateAsync GetProjects;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly Action<bool> _setConnectivityError;

        public SubscribedProjectsForm(IAzureAPI api, CancellationTokenSource cancellationToken)
        {
            InitializeComponent();
            new SubscribedProjectsPresenter(this, api);

            _cancellationTokenSource = cancellationToken;
            adgvSubbed.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void SubscribedProjects_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable subbed = await GetProjects?.Invoke();

                adgvSubbed.DataSource = null;
                adgvSubbed.AutoGenerateColumns = true;
                adgvSubbed.Refresh();

                adgvSubbed.DataSource = subbed;
                adgvSubbed.Refresh();
            }
            catch (TaskCanceledException) { /* swallow - app is closing */ }
            catch (Exception ex)
            {
                // some other error happened
                MessageBox.Show($"{ex.Message}\n{ex.InnerException.Message}\n Check the Windows Event Viewer for more information.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _setConnectivityError(false);
            };
        }
    }
}