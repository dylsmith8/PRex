using System.Threading.Tasks;

namespace PullRequestExtractor.Interfaces
{
    public delegate Task<bool> PingAzureAsync();

    public interface IMainView
    {
        event PingAzureAsync Ping;
    }
}