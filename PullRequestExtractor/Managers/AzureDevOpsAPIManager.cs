using Newtonsoft.Json;
using PullRequestExtractor.Helpers;
using PullRequestExtractor.Interfaces;
using PullRequestExtractor.Models;
using PullRequestExtractor.Models.PullRequests;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Project = PullRequestExtractor.Models.Projects.Project;

namespace PullRequestExtractor.Managers
{
    public class AzureDevOpsAPIManager : IAzureAPI
    {
        private readonly string _pat;
        private readonly string _org;
        private readonly string _project;

        private readonly CancellationTokenSource _cancellationTokenSource;

        public IAppSettings Settings => new AppSettings();

        public AzureDevOpsAPIManager(CancellationTokenSource cancellationTokenSource)
        {
            IAppSettings settings = Settings;
            _cancellationTokenSource = cancellationTokenSource;

            if (!settings.TryGetAppSetting("PAT", out _pat))
                throw new InvalidOperationException("Could not find a valid personal access token for Azure DevOps");

            if (!settings.TryGetAppSetting("Org", out _org))
                throw new InvalidOperationException("Could not find an Organisation for Azure DevOps");

            if (!settings.TryGetAppSetting("ActiveProject", out _project))
                throw new InvalidOperationException("Could not find an Organisation for Azure DevOps");
        }

        public async Task<Project> GetAuthedProjectsAsync()
        {
            HttpStatusCode statusCode = new HttpStatusCode();

            return await Executor<Project>.TryExecute(async delegate
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = BuildAuthenticationHeader();

                    using (HttpResponseMessage response = await client.GetAsync($"https://dev.azure.com/{_org}/_apis/projects", _cancellationTokenSource.Token))
                    {
                        statusCode = response.StatusCode;
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Project>(responseBody);
                    }
                }
            });
        }

        public async Task<PullRequest> GetActivePullRequestsAsync()
        {
            return await Executor<PullRequest>.TryExecute(async delegate
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = BuildAuthenticationHeader();

                    using (HttpResponseMessage response = await client.GetAsync($"https://dev.azure.com/{_org}/{_project}/_apis/git/pullrequests?api-version=6.0", _cancellationTokenSource.Token))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<PullRequest>(responseBody);
                    }
                }
            });
        }

        public async Task<PullRequest> GetArchivedPullRequestsAsync()
        {
            return await Executor<PullRequest>.TryExecute(async delegate
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = BuildAuthenticationHeader();

                    using (HttpResponseMessage response = await client.GetAsync($"https://dev.azure.com/{_org}/{_project}/_apis/git/pullrequests?searchCriteria.status=completed&api-version=6.0", _cancellationTokenSource.Token))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<PullRequest>(responseBody);
                    }
                }
            });
        }

        public async Task<GitRepository> GetRepositories()
        {
            return await Executor<GitRepository>.TryExecute(async delegate
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = BuildAuthenticationHeader();

                    using (HttpResponseMessage response = await client.GetAsync($"https://dev.azure.com/{_org}/{_project}/_apis/git/repositories?api-version=6.0", _cancellationTokenSource.Token))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<GitRepository>(responseBody);
                    }
                }
            });
        }

        public async Task<bool> Ping()
        {
            var authed = await GetAuthedProjectsAsync();
            return authed.count != 0;
        }

        private AuthenticationHeaderValue BuildAuthenticationHeader()
        {
            return new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(
                    System.Text.Encoding.ASCII.GetBytes(
                        string.Format("{0}:{1}", string.Empty, _pat))
                    )
                );
        }       
    }
}