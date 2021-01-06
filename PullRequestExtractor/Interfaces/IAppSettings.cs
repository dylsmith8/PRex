namespace PullRequestExtractor.Interfaces
{
    public interface IAppSettings
    {
        bool TryGetAppSetting(string key, out string value);
    }
}
