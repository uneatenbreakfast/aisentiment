using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Tweet
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public double Sentiment { get; set; }
    }
}