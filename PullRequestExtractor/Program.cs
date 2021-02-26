using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Managers;
using PullRequestExtractor.Presenters;
using System;
using System.Windows.Forms;

namespace PullRequestExtractor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (MainPresenter presenter = new MainPresenter())
            {
                presenter.Start();
                Application.Run();
            }
        }
    }
}
