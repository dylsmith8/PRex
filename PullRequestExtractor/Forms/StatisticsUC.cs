using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PullRequestExtractor.Forms
{
    public partial class StatisticsUC : UserControl, IStatisticsView
    {
        public event GetRepositoriesDelegate GetRepositories;
        
        public StatisticsUC(IAzureAPI api)
        {
            InitializeComponent();
            new StatisticsPresenter(this, api);
        }
    }
}
