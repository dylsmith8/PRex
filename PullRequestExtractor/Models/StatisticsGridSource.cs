namespace PullRequestExtractor.Models
{
    public class StatisticsGridSource
    {
        public int CompletedPullRequests { get; set; }
        public int TotalComments { get; set; }
        public int TotalCommits { get; set; }
        public string MostActiveRepo { get; set; }
    }
}
