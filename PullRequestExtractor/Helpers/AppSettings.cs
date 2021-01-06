using PullRequestExtractor.Interfaces;
using System.Configuration;

namespace PullRequestExtractor.Helpers
{
    internal sealed class AppSettings : IAppSettings
    {
        bool IAppSettings.TryGetAppSetting(string key, out string value)
        {
            try
            {
                value = ConfigurationManager.AppSettings[key];
                return true;
            }
            catch (ConfigurationErrorsException)
            {
                value = null;
                return false;
            }
        }
    }
}
