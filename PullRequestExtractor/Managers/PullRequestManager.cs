using Newtonsoft.Json;
using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Models.PullRequests;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PullRequestExtractor.Managers
{
    public class PullRequestManager
    {
        private readonly string _pat;

        public PullRequestManager(IAppSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (!settings.TryGetAppSetting("PAT", out _pat))
                throw new InvalidOperationException("Could not find a valid personal access token for Azure DevOps");
        }

        // error handling and use params to be more specific in API request
        internal async Task<PullRequest> GetPullRequestsAsync(string organisation, string project)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        System.Text.Encoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", string.Empty, _pat))));

                using (HttpResponseMessage response = await client.GetAsync($"https://dev.azure.com/{organisation}/{project}/_apis/git/pullrequests?api-version=6.0"))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PullRequest>(responseBody);
                }
            }
        }
    }
}
