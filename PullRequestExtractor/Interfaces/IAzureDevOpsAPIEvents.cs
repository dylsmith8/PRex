using PullRequestExtractor.Models.PullRequests;
using System.Threading.Tasks;
using Project = PullRequestExtractor.Models.Projects.Project;

namespace PullRequestExtractor.Interfaces
{
    public delegate Task<Project> GetProjectsDelegate();
    public delegate Task<PullRequest> GetActivePullRequestsDelegate();
    public delegate Task<PullRequest> GetArchivedPullRequestsDelegate();

    public interface IAzureDevOpsAPIEvents
    {
        event GetProjectsDelegate GetProjects;
        event GetActivePullRequestsDelegate GetActivePullRequests;
        event GetArchivedPullRequestsDelegate GetArchivedPullRequests;
    }
}