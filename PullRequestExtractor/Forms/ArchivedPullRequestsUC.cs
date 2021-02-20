using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PullRequestExtractor.Forms
{
    public partial class ArchivedPullRequestsUC : UserControl, IArchivedPRView
    {
        public event GetArchivedPullRequestsDelegate GetArchivedPullRequests;

        private CancellationTokenSource _cancellationTokenSource;

        private readonly int _pollingInterval;
        private readonly string _project;
        private readonly string _org;

        public ArchivedPullRequestsUC(IAzureAPI api, CancellationTokenSource cancellationToken)
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
        }

        private void adgvArchived_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenPullRequestInBrowser(e, adgvArchived);
        }

        private void OpenPullRequestInBrowser(DataGridViewCellEventArgs e, DataGridView dgv)
        {
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            string repo = row.Cells["Repo"]?.Value.ToString();
            string codeReviewId = row.Cells["CodeReviewId"]?.Value.ToString();

            string uri = $"https://dev.azure.com/{_org}/{_project}/_git/{repo}/pullrequest/{codeReviewId}";

            Process.Start(uri);
        }

        private async void btnArchPrs_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable prs = null;

                if (!_cancellationTokenSource.IsCancellationRequested)
                {
                    prs = await GetArchivedPullRequests?.Invoke();

                    adgvArchived.DataSource = null;
                    adgvArchived.AutoGenerateColumns = true;
                    adgvArchived.Refresh();

                    adgvArchived.DataSource = prs;
                    adgvArchived.Refresh();
                }                    
            }
            catch (TaskCanceledException) { MessageBox.Show("Cannot retrieve archived PRs.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.InnerException.Message}\n\n. Check the Windows Event Viewer for more information.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }
    }
}
