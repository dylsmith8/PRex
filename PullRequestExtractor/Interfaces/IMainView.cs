using System.Threading.Tasks;
using Project = PullRequestExtractor.Models.Projects.Project;

namespace PullRequestExtractor.Interfaces
{
    public delegate Task<Project> GetProjectsDelegate();

    public interface IMainView
    {
        event GetProjectsDelegate GetProjects;
    }
}