﻿using PullRequestExtractor.Forms;
using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Managers;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PullRequestExtractor.Presenters
{
    public class MainPresenter : IDisposable
    {
        private bool disposedValue;
        private MainForm _mainForm;
        private CancellationTokenSource _cancellationTokenSource;

        private Action<bool> _setConnectivityError;

        private IAzureAPI _azureDevOpsManager;

        public void Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _azureDevOpsManager = new AzureDevOpsAPIManager(_cancellationTokenSource);

            _mainForm = new MainForm(_azureDevOpsManager, _cancellationTokenSource);
            
            DoEventPlumbing();

            AddControlToTabPage(_mainForm.tcActivePrs, new ActivePullRequestsUC(_azureDevOpsManager, _cancellationTokenSource, _setConnectivityError));
            AddControlToTabPage(_mainForm.tcPrArchive, new ArchivedPullRequestsUC(_azureDevOpsManager, _cancellationTokenSource, _setConnectivityError));
            AddControlToTabPage(_mainForm.tcStats, new StatisticsUC(_azureDevOpsManager));
            AddControlToTabPage(_mainForm.tcRepos, new ReposUC(_azureDevOpsManager, _cancellationTokenSource, _setConnectivityError));

            _mainForm.Show();
        }

        private void AddControlToTabPage(Control tabPage, Control controlToAdd)
        {
            tabPage.Controls.Clear();
            controlToAdd.Dock = DockStyle.Fill;
            controlToAdd.Parent = tabPage;
            tabPage.Controls.Add(controlToAdd);
        }

        private void DoEventPlumbing()
        {
            _mainForm.Closing += CloseApplication;
            _mainForm.Ping += _mainForm_Ping;
            _setConnectivityError = _mainForm.SetUISuccessOrFailure;
        }

        private async Task<bool> _mainForm_Ping()
        {
            return await _azureDevOpsManager.Ping();
        }

        private static void CloseApplication(object sender, CancelEventArgs e)
        {
            if (!e.Cancel)
                Application.Exit(e);
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
