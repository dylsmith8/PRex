namespace PullRequestExtractor.Models
{
    public class CompletedGridSource : PullRequestGridSource
    {
        public string ClosedDate { get; set; }
        public string MergeStatus { get; set; }
    }
}
