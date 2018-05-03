using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FinalStore
    {
        public static List<Tweet> TweetStore = new List<Tweet>();

        public static void AddTweet(Tweet tweet)
        {
            tweet.Created = DateTime.UtcNow;
            tweet.Sentiment = SentimentAnalysis.GetSentiment(tweet.Text);
            TweetStore.Add(tweet);
        }

        public static List<Tweet> GetTweets()
        {
            return TweetStore;
        }

        public static void Reset()
        {
            TweetStore.Clear();
        }
    }
}