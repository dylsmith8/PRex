using PullRequestExtractor.Helpers;
using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Managers;
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
        private IAppSettings _appSetttings;

        public void Start()
        {
            _appSetttings = new AppSettings();
            _mainForm = new MainForm(_appSetttings);

            DoPlumbing();

            _mainForm.Show();
        }

        private void DoPlumbing()
        {
            _mainForm.Closing += CloseApplication;
            _mainForm.GetPullRequests += _mainForm_GetPullRequests;
            _mainForm.GetProjects += _mainForm_GetProjects;
        }

        private async Task<Models.Projects.Project> _mainForm_GetProjects()
        {
            return await new ProjectManager(_appSetttings).GetAuthedProjectsAsync();
        }

        private async Task<Models.PullRequests.PullRequest> _mainForm_GetPullRequests(string organisation, string project)
        {
            return await new PullRequestManager(_appSetttings).GetPullRequestsAsync(organisation, project);
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
