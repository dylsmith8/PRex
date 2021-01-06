using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Models;
using PullRequestExtractor.Models.Projects;
using PullRequestExtractor.Models.PullRequests;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PullRequestExtractor
{
    public partial class MainForm : Form, IProject, IPullRequest
    {
        private readonly string _project;
        private readonly string _org;

        public event GetProjectsDelegate GetProjects;
        public event GetPullRequestsDelegate GetPullRequests;

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
                    SourceBranch = pr.sourceRefName,
                    TargetBranch = pr.targetRefName,
                    CodeReviewId = pr.codeReviewId
                });

            var dgvBindingSource = new BindingSource(dgvSource, null);
            dgvPRs.DataSource = dgvBindingSource;
            dgvPRs.AutoGenerateColumns = true;
            dgvPRs.Refresh();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvPRs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvPRs.Rows[e.RowIndex];
            string repo = row.Cells["Repo"]?.Value.ToString();
            string codeReviewId = row.Cells["CodeReviewId"]?.Value.ToString();

            string uri = $"https://dev.azure.com/{_org}/{_project}/_git/{repo}/pullrequest/{codeReviewId}";

            Debug.WriteLine(uri);
            OpenPullRequest(uri);           
        }

        private static void OpenPullRequest(string prUrl)
        {
            Process.Start(prUrl);
        }
    }
}
