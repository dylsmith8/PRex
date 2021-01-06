﻿using System;
using System.Collections.Generic;

namespace PullRequestExtractor.Models.Projects
{
    public class Value
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string state { get; set; }
        public int revision { get; set; }
        public string visibility { get; set; }
        public DateTime lastUpdateTime { get; set; }
        public string description { get; set; }
    }

    public class Project
    {
        public int count { get; set; }
        public List<Value> value { get; set; }
    }
}
