using PullRequestExtractor.Interfaces;
using System;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PullRequestExtractor
{
    public partial class MainForm : Form, IMainView
    {
        private readonly string _project;
        private readonly string _org;

        public event GetProjectsDelegate GetProjects;

        private CancellationTokenSource _cancellationTokenSource;

        public MainForm(IAppSettings appSettings, CancellationTokenSource cancellationTokenSource)
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

            InitializeComponent();
            lblOrgPlaceHolder.Text = _org;
            lblProjectPlaceHolder.Text = _project;
            _cancellationTokenSource = cancellationTokenSource;

            lblStatusText.Text = "Not authenticated";
            lblStatusColour.BackColor = Color.Red;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnExit_Click(sender, e);
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
                _cancellationTokenSource.Cancel();
                Application.Exit();
            }

            if (projects != null && projects.value.Count > 0)
            {
                lblStatusText.Text = "Success";
                lblStatusColour.BackColor = Color.LimeGreen;
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
    }
}