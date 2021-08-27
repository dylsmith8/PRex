using System.Data;
using System.Threading.Tasks;

namespace PullRequestExtractor.Interfaces
{
    public delegate Task<DataTable> GetProjectsDelegateAsync();

    public interface IGetSubscribedProjects
    {
        event GetProjectsDelegateAsync GetProjects;
    }
}
