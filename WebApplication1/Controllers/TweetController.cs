using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using WebApplication1.Models;
using System.Configuration;
using System.Linq;


namespace WebApplication1.Controllers
{
    public class TweetController : Controller
    {
        public async Task<ActionResult> Index(string data)
        {
            var model = new TweetViewModel();

            if (data.IsNullOrWhiteSpace())
            {
                model.AllData = "Like: http://localhost:49901/Tweet/?data=onepunchman";
                model.TweetData = FinalStore.GetTweets();

                var jj = new SentimentAnalysis();
            }
            else
            {
                TwitterAdapter.ConsumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"];
                TwitterAdapter.ConsumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"];
                var results = await TwitterAdapter.SearchAsync(data);

                model.AllData = results;
            }

            return View(model);
        }

        public async Task<ActionResult> ShowGraph()
        {
            var allTweets = FinalStore.GetTweets();
            var model = new TweetViewModel();

            model.TweetData = allTweets;
            model.AverageSentiment = allTweets.Count > 0 ? allTweets.Average(x => x.Sentiment) : -1;
            return View(model);
        }

        public ActionResult AddTweet(Tweet tweet)
        {
            FinalStore.AddTweet(tweet);
            return RedirectToAction("Index");
        }

        public ActionResult Reset()
        {
            FinalStore.Reset();
            return RedirectToAction("Index");
        }
    }

}