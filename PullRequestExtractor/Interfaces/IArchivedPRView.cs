using PullRequestExtractor.Models.PullRequests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PullRequestExtractor.Interfaces
{
    public delegate Task<DataTable> GetArchivedPullRequestsDelegate();
    public interface IArchivedPRView
    {
        event GetArchivedPullRequestsDelegate GetArchivedPullRequests;
    }
}
