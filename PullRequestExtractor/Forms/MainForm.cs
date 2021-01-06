using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Models;
using PullRequestExtractor.Models.PullRequests;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PullRequestExtractor
{
    public partial class MainForm : Form, IProject, IPullRequest
    {
        private readonly string _project;
        private readonly string _org;

        public event GetProjectsDelegate GetProjects;
        public event GetPullRequestsDelegate GetPullRequests;

        private CancellationTokenSource _cancellationTokenSource;

        public MainForm(IAppSettings appSettings)
        {
            if (appSettings == null)
                throw new ArgumentNullException(nameof(appSettings));

            if (!appSettings.TryGetAppSetting("ActiveProject", out _project))
                throw new InvalidOperationException("Could not find a valid personal access token for Azure DevOps");

            if (!appSettings.TryGetAppSetting("Org", out _org))
                throw new InvalidOperationException("Could not find a Organisation for Azure DevOps");

            InitializeComponent();
            lblOrgPlaceHolder.Text = _org;
            lblProjectPlaceHolder.Text = _project;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private async void TestGetProjects_Click(object sender, EventArgs e)
        {
            Models.Projects.Project projects = await GetProjects?.Invoke();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Authenticated projects:\n");

            foreach (var project in projects.value)
                sb.AppendLine(project.name);

            MessageBox.Show(sb.ToString());
        }

        private async void TestGetPRs_Click(object sender, EventArgs e)
        {
            PullRequest prs = await GetPullRequests?.Invoke(_org, _project);
            ParsePullRequestData(prs);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
            Application.Exit();
        }

        private void dgvPRs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvPRs.Rows[e.RowIndex];
            string repo = row.Cells["Repo"]?.Value.ToString();
            string codeReviewId = row.Cells["CodeReviewId"]?.Value.ToString();

            string uri = $"https://dev.azure.com/{_org}/{_project}/_git/{repo}/pullrequest/{codeReviewId}";

            Debug.WriteLine(uri);
            Process.Start(uri);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Models.Projects.Project projects = await GetProjects?.Invoke();

            if (projects.value.Count > 0)
            {
                lblStatusText.Text = "Success";
                lblStatusColour.BackColor = Color.LimeGreen;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Authenticated projects:\n");

                foreach (var project in projects.value)
                    sb.AppendLine(project.name);

                MessageBox.Show(sb.ToString());
                try
                {
                    await ListenForNewPullRequests();
                }
                catch (TaskCanceledException ex) { MessageBox.Show("Poll attempts ended."); }
            }
            else
            {
                lblStatusText.Text = "Failed";
                lblStatusColour.BackColor = Color.Orange;
            }
        }

        private async Task ListenForNewPullRequests()
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                PullRequest prs = await GetPullRequests?.Invoke(_org, _project);
                ParsePullRequestData(prs);
                await Task.Delay(10000, _cancellationTokenSource.Token);
            }
        }

        private void ParsePullRequestData(PullRequest prs)
        {
            List<PullRequestGridSource> dgvSource = new List<PullRequestGridSource>();

            foreach (var pr in prs.value)
                dgvSource.Add(new PullRequestGridSource
                {
                    Title = pr.title,
                    Repo = pr.repository.name,
                    CreationDate = pr.creationDate,
                    Author = pr.createdBy.displayName,
                    Status = pr.status,
                    Reviewers = string.Join(",", pr.reviewers.Select(x => x.displayName)),
                    SourceBranch = pr.sourceRefName.Substring(pr.sourceRefName.LastIndexOf(@"/")),
                    TargetBranch = pr.targetRefName.Substring(pr.targetRefName.LastIndexOf(@"/")),
                    CodeReviewId = pr.codeReviewId
                });

            dgvPRs.DataSource = null;
            dgvPRs.AutoGenerateColumns = true;
            dgvPRs.Refresh();

            var dgvBindingSource = new BindingSource(dgvSource, null);
            dgvPRs.DataSource = dgvBindingSource;
            
            dgvPRs.Refresh();
        }
    }
}
