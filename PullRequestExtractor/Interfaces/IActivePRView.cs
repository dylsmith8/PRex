using PullRequestExtractor.Models;
using PullRequestExtractor.Models.PullRequests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullRequestExtractor.Interfaces
{
    public delegate Task<DataTable> GetActivePullRequestsDelegate();
    public interface IActivePRView
    {
        event GetActivePullRequestsDelegate GetActivePullRequests;
    }
}
