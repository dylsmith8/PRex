using System.Data;
using System.Threading.Tasks;

namespace PullRequestExtractor.Interfaces.IArchivedPRView
{
    public delegate Task<DataTable> GetArchivedPullRequestsDelegate();
    public delegate void OpenPullRequestDelegate(string codeReviewId, string repository, string org, string project);
    public interface IArchivedPRView
    {
        event GetArchivedPullRequestsDelegate GetArchivedPullRequests;
        event OpenPullRequestDelegate OpenPullRequest;
    }
}
