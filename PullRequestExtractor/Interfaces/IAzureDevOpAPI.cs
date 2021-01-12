using PullRequestExtractor.Models.PullRequests;
using System.Threading.Tasks;
using Project = PullRequestExtractor.Models.Projects.Project;

namespace PullRequestExtractor.Interfaces
{
    public delegate Task<Project> GetProjectsDelegate();
    public delegate Task<PullRequest> GetPullRequestsDelegate(string organisation, string project);

    public interface IAzureDevOpAPI
    {
        event GetProjectsDelegate GetProjects;
        event GetPullRequestsDelegate GetPullRequests;
    }
}