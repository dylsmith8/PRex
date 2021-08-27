using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Interfaces.IArchivedPRView;
using PullRequestExtractor.Presenters;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PullRequestExtractor.Forms
{
    public partial class ArchivedPullRequestsUC : UserControl, IArchivedPRView
    {
        public event GetArchivedPullRequestsDelegate GetArchivedPullRequests;
        public event OpenPullRequestDelegate OpenPullRequest;

        private CancellationTokenSource _cancellationTokenSource;
        private readonly Action<bool> _setConnectivityError;

        private readonly int _pollingInterval;
        private readonly string _project;
        private readonly string _org;

        public ArchivedPullRequestsUC(IAzureAPI api, CancellationTokenSource cancellationToken, Action<bool> setConnectivityError)
        {
            InitializeComponent();
            new ArchivedPullRequestPresenter(this, api);

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
            _setConnectivityError = setConnectivityError;
        }

        private async void btnArchPrs_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable prs = null;

                if (!_cancellationTokenSource.IsCancellationRequested)
                {
                    prs = await GetArchivedPullRequests?.Invoke();

                    _setConnectivityError(true);

                    adgvArchived.DataSource = null;
                    adgvArchived.AutoGenerateColumns = true;
                    adgvArchived.Refresh();

                    adgvArchived.DataSource = prs;
                    adgvArchived.Refresh();
                }                    
            }
            catch (TaskCanceledException) { /* swallow - app is closing */ }
            catch (Exception ex)
            {
                // some other error happened
                MessageBox.Show($"{ex.Message}\n{ex.InnerException.Message}.\n Check the Windows Event Viewer for more information.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _setConnectivityError(false);
            };
        }

        private void adgvArchived_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = adgvArchived.Rows[e.RowIndex];
            string repo = row.Cells["Repo"]?.Value.ToString();
            string codeReviewId = row.Cells["PullRequestId"]?.Value.ToString();

            OpenPullRequest(codeReviewId, repo, _org, _project);
        }
    }
}
