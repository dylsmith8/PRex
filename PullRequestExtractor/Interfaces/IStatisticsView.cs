using PullRequestExtractor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullRequestExtractor.Interfaces
{
    public delegate Task<GitRepository> GetRepositoriesDelegate();
    public interface IStatisticsView
    {
        event GetRepositoriesDelegate GetRepositories;
    }
}
