using PullRequestExtractor.Helpers;
using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Models;
using PullRequestExtractor.Models.PullRequests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace PullRequestExtractor
{
    public partial class MainForm : Form, IAzureDevOpsAPIEvents
    {
        private readonly string _project;
        private readonly string _org;
        private readonly int _pollingInterval;

        public event GetProjectsDelegate GetProjects;
        public event GetActivePullRequestsDelegate GetActivePullRequests;
        public event GetArchivedPullRequestsDelegate GetArchivedPullRequests;

        private CancellationTokenSource _cancellationTokenSource;

        private List<PullRequestGridSource> _seenPullRequests = new List<PullRequestGridSource>();

        public MainForm(IAppSettings appSettings)
        {
            if (appSettings == null)
                throw new ArgumentNullException(nameof(appSettings));

            if (!appSettings.TryGetAppSetting("ActiveProject", out _project))
                throw new InvalidOperationException("Could not find a valid personal access token for Azure DevOps");

            if (!appSettings.TryGetAppSetting("Org", out _org))
                throw new InvalidOperationException("Could not find an Organisation for Azure DevOps");

            string pollingInterval;
            if (!appSettings.TryGetAppSetting("PollingInterval", out pollingInterval))
                throw new InvalidOperationException("Could not find a valid polling interval");

            if (!int.TryParse(pollingInterval, out _pollingInterval))
                throw new InvalidOperationException("Could not parse the polling interval");

            InitializeComponent();
            lblOrgPlaceHolder.Text = _org;
            lblProjectPlaceHolder.Text = _project;
            _cancellationTokenSource = new CancellationTokenSource();

            lblStatusText.Text = "Not authenticated";
            lblStatusColour.BackColor = Color.Red;

            
            dgvArchived.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private async void TestGetProjects_Click(object sender, EventArgs e)
        {
            Models.Projects.Project projects = await GetProjects?.Invoke();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Authenticated projects:\n");

            foreach (var project in projects.value)
                sb.AppendLine(project.name);

            MessageBox.Show(sb.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void TestGetPRs_Click(object sender, EventArgs e)
        {
            try
            {
                PullRequest prs = await GetActivePullRequests?.Invoke();
                ParseActivePullRequestData(prs, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.InnerException.Message}\n\nApp will now terminate. Check the Windows Event Viewer for more information.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnExit_Click(sender, e);
        }

        private void dgvPRs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenPullRequestInBrowser(e, dgvPRs);
        }

        private void dgvArchived_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenPullRequestInBrowser(e, dgvArchived);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Models.Projects.Project projects = null;

            try
            {
                projects = await GetProjects?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.InnerException.Message}\n\nApp will now terminate. Check the Windows Event Viewer for more information.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (projects != null && projects.value.Count > 0)
            {
                lblStatusText.Text = "Success";
                lblStatusColour.BackColor = Color.LimeGreen;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Authenticated projects:\n");

                foreach (var project in projects.value)
                    sb.AppendLine(project.name);

                sb.AppendLine("\nPull request polling will initiate automatically and the UI will update accordingly.");

                MessageBox.Show(sb.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    await ListenForNewPullRequests(true);
                }
                catch (TaskCanceledException) { MessageBox.Show("Poll attempts ended. Exiting.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}\n{ex.InnerException.Message}\n\nApp will now terminate. Check the Windows Event Viewer for more information.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else
            {
                lblStatusText.Text = "Failed";
                lblStatusColour.BackColor = Color.Orange;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                Hide();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            notifyIcon.Visible = false;
            TopMost = true;
            WindowState = FormWindowState.Normal;
        }

        private async void btnArchPrs_Click(object sender, EventArgs e)
        {
            try
            {
                PullRequest prs = await GetArchivedPullRequests?.Invoke();
                ParseArchivedPullRequests(prs);
            }
            catch (TaskCanceledException) { MessageBox.Show("Cannot retrieve archived PRs.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.InnerException.Message}\n\n. Check the Windows Event Viewer for more information.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void txtBoxFilter_TextChanged(object sender, EventArgs e)
        {
            string query = txtBoxFilter.Text;
            List<string> queries = new List<string>();

            foreach (DataGridViewTextBoxColumn col in dgvArchived.Columns)
                queries.Add($"{col.Name} LIKE '%{query}%'");

            if (queries.Any())
            {
                var queryFilter = string.Join(" OR ", queries);
                ((DataTable)dgvArchived.DataSource).DefaultView.RowFilter = queryFilter;
            }
        }

        private async Task ListenForNewPullRequests(bool isStartup)
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                PullRequest prs = await GetActivePullRequests?.Invoke();
                ParseActivePullRequestData(prs, isStartup);
                isStartup = false;

                await Task.Delay(_pollingInterval, _cancellationTokenSource.Token);
            }
        }

        private void ParseArchivedPullRequests(PullRequest prs)
        {
            List<CompletedGridSource> dgvSource = new List<CompletedGridSource>();

            foreach (var pr in prs.value)
            {
                var src = new CompletedGridSource
                {
                    CodeReviewId = pr.codeReviewId.ToString(),
                    Title = pr.title,
                    Repo = pr.repository.name,
                    CreationDate = pr.creationDate.ToLocalTime().ToShortDateString(),
                    Author = pr.createdBy.displayName,
                    Status = pr.status,
                    Reviewers = string.Join(", ", pr.reviewers.Select(x => x.displayName)),
                    SourceBranch = pr.sourceRefName.Substring(pr.sourceRefName.LastIndexOf(@"/")),
                    TargetBranch = pr.targetRefName.Substring(pr.targetRefName.LastIndexOf(@"/")),
                    
                    MergeStatus = pr.mergeStatus,
                    ClosedDate = pr.closedDate.ToLocalTime().ToShortDateString()
                };

                dgvSource.Add(src);
            }           

            dgvSource.OrderByDescending(x => x.CreationDate);
            DataTable dt = Util.ToDataTable(dgvSource);

            dgvArchived.DataSource = null;
            dgvArchived.AutoGenerateColumns = true;
            dgvArchived.Refresh();

            dgvArchived.DataSource = dt;
            dgvArchived.Refresh();
        } 

        private void ParseActivePullRequestData(PullRequest prs, bool isStartup)
        {
            List<PullRequestGridSource> dgvSource = new List<PullRequestGridSource>();

            foreach (var pr in prs.value)
            {
                var src = new PullRequestGridSource
                {
                    CodeReviewId = pr.codeReviewId.ToString(),
                    Title = pr.title,
                    Repo = pr.repository.name,
                    CreationDate = pr.creationDate.ToLocalTime().ToString(),
                    Author = pr.createdBy.displayName,
                    Status = pr.status,
                    Reviewers = string.Join(", ", pr.reviewers.Select(x => x.displayName)),
                    SourceBranch = pr.sourceRefName.Substring(pr.sourceRefName.LastIndexOf(@"/")),
                    TargetBranch = pr.targetRefName.Substring(pr.targetRefName.LastIndexOf(@"/")),
                };

                dgvSource.Add(src);
            }

            if (!isStartup) // don't need to display toasts at start up
            {
                // check if there's new pull requests coming from the API to notify user about
                // should only notify user if we haven't seen it before
                var distict = dgvSource.Except(_seenPullRequests, new PullRequestComparer()).ToList();
                if (distict.Count == 1)
                    CreateToast(distict.Single().Title, distict.Single().Author);
                else if (distict.Count >= 2)
                    CreateToast(distict.Count);
            }

            _seenPullRequests = dgvSource;

            dgvPRs.DataSource = null;
            dgvPRs.AutoGenerateColumns = true;
            dgvPRs.Refresh();

            var dgvBindingSource = new BindingSource(dgvSource, null);
            dgvPRs.DataSource = dgvBindingSource;
            dgvPRs.Refresh();
        }

        private static void CreateToast(int newPrs)
        {
            DisplayToast("New pull requests for your attention", $"{newPrs} Pull Requests have been added.");
        }

        private static void CreateToast(string pullRequestName, string author)
        {
            DisplayToast("A new pull request has been added", $"A new pull request with title '{pullRequestName}' has been added by {author}.");
        }

        private static void DisplayToast(string title, string content)
        {
            using (PopupNotifier notifier = new PopupNotifier())
            {
                notifier.TitleText = title;
                notifier.ContentText = content;
                notifier.IsRightToLeft = false;
                notifier.Popup();
            }
        }

        private void OpenPullRequestInBrowser(DataGridViewCellEventArgs e, DataGridView dgv)
        {
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            string repo = row.Cells["Repo"]?.Value.ToString();
            string codeReviewId = row.Cells["CodeReviewId"]?.Value.ToString();

            string uri = $"https://dev.azure.com/{_org}/{_project}/_git/{repo}/pullrequest/{codeReviewId}";

            Debug.WriteLine(uri);
            Process.Start(uri); // will start the default browser
        }
    }
}