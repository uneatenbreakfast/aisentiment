using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TweetViewModel
    {
        public string AllData { get; set; }
        public List<Tweet> TweetData { get; set; }

        public double AverageSentiment { get; set; }
    }
}

