using PullRequestExtractor.Forms;
using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Managers;
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

        private readonly IAzureAPI _api;
        private CancellationTokenSource _cancellationTokenSource;

        public event PingAzureAsync Ping;

        public MainForm(IAzureAPI api, CancellationTokenSource cancellationTokenSource)
        {
            if (api == null)
                throw new ArgumentNullException(nameof(api));

            if (!api.Settings.TryGetAppSetting("ActiveProject", out _project))
                throw new InvalidOperationException("Could not find a valid personal access token for Azure DevOps");

            if (!api.Settings.TryGetAppSetting("Org", out _org))
                throw new InvalidOperationException("Could not find an Organisation for Azure DevOps");

            string pollingInterval;
            if (!api.Settings.TryGetAppSetting("PollingInterval", out pollingInterval))
                throw new InvalidOperationException("Could not find a valid polling interval");

            _api = api;

            InitializeComponent();
            lblOrgPlaceHolder.Text = _org;
            lblProjectPlaceHolder.Text = _project;
            _cancellationTokenSource = cancellationTokenSource;

            lblStatusText.Text = "Not authenticated";
            lblStatusColour.BackColor = Color.Red;
        }

        private async void TestGetProjects_Click(object sender, EventArgs e)
        {
            using (SubscribedProjectsForm frm = new SubscribedProjectsForm(_api, _cancellationTokenSource))
                frm.ShowDialog();            
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
            try
            {
                bool authed = await Ping?.Invoke();
                if (!authed)
                    SetUISuccessOrFailure(false);
            }
            catch
            {
                MessageBox.Show($"Unable to connect to the Azure DevOps API start up - check the event view", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetUISuccessOrFailure(false);
            }
        }

        public void SetUISuccessOrFailure(bool success)
        {
            if (success)
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