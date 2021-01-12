using PullRequestExtractor.Interfaces;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PullRequestExtractor.Presenters
{
    public class MainPresenter : IDisposable
    {
        private bool disposedValue;
        private MainForm _mainForm;

        private IAzureDevOps _azureDevOpsManager;

        public void Start(IAzureDevOps azureDevOps)
        {
            _azureDevOpsManager = azureDevOps;
            _mainForm = new MainForm(azureDevOps.Settings);

            DoPlumbing();

            _mainForm.Show();
        }

        private void DoPlumbing()
        {
            _mainForm.Closing += CloseApplication;
            _mainForm.GetActivePullRequests += _mainForm_GetActivePullRequests;
            _mainForm.GetProjects += _mainForm_GetProjects;
            _mainForm.GetArchivedPullRequests += _mainForm_GetArchivedPullRequests;
        }

        private async Task<Models.Projects.Project> _mainForm_GetProjects()
        {
            return await _azureDevOpsManager.GetAuthedProjectsAsync();
        }

        private async Task<Models.PullRequests.PullRequest> _mainForm_GetActivePullRequests()
        {
            return await _azureDevOpsManager.GetActivePullRequestsAsync();
        }

        private Task<Models.PullRequests.PullRequest> _mainForm_GetArchivedPullRequests()
        {
            throw new NotImplementedException();
        }

        private static void CloseApplication(object sender, CancelEventArgs e)
        {
            if (!e.Cancel)
            {
                Application.Exit(e);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing && _mainForm != null)
                    _mainForm.Dispose();
                 
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
