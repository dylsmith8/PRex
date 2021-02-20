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
    public partial class ActivePullRequestsUC : UserControl, IActivePRView
    {
        public event GetActivePullRequestsDelegate GetActivePullRequests;
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

        private void dgvPRs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenPullRequestInBrowser(e, dgvPRs);
        }

        private async void ActivePullRequestsUC_Load(object sender, EventArgs e)
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                await GetActivePRs(sender, e);
                await Task.Delay(_pollingInterval, _cancellationTokenSource.Token);
            }
        }

        private void OpenPullRequestInBrowser(DataGridViewCellEventArgs e, DataGridView dgv)
        {
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            string repo = row.Cells["Repo"]?.Value.ToString();
            string codeReviewId = row.Cells["CodeReviewId"]?.Value.ToString();

            string uri = $"https://dev.azure.com/{_org}/{_project}/_git/{repo}/pullrequest/{codeReviewId}";

            Process.Start(uri);
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
    }
}
