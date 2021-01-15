using System;

namespace PullRequestExtractor.Models
{
    public class CompletedGridSource : PullRequestGridSource
    {
        public DateTime ClosedDate { get; set; }
        public string MergeStatus { get; set; }
    }
}
