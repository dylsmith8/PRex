﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PullRequestExtractor
{
    public class ListofProjectsResponse
    {
        public class Projects : BaseViewModel
        {
            public int count { get; set; }
            public Value[] value { get; set; }
        }

        public class Value
        {
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string url { get; set; }
            public string state { get; set; }
        }

    }

    public class BaseViewModel
    {
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
