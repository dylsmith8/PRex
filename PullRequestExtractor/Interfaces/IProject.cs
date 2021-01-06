using PullRequestExtractor.Models.Projects;
using System.Threading.Tasks;

namespace PullRequestExtractor.Interfaces
{
    public delegate Task<Project> GetProjectsDelegate();
    public interface IProject
    {
        event GetProjectsDelegate GetProjects;
    }
}