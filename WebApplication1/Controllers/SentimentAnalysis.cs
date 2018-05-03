using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SentimentAnalysis
    {
        public static double GetSentiment(string msg)
        {
            // Create a client.
            ITextAnalyticsAPI client = new TextAnalyticsAPI();
            client.AzureRegion = AzureRegions.Westcentralus;
            client.SubscriptionKey = "d828157edb4e4ceaa79109372f3d18c4";

            Console.OutputEncoding = System.Text.Encoding.UTF8;


            SentimentBatchResult result3 = client.Sentiment(
                    new MultiLanguageBatchInput(
                        new List<MultiLanguageInput>()
                        {
                    new MultiLanguageInput("en", "0", msg)
                        }));


            // Printing sentiment results
            foreach (var document in result3.Documents)
            {
                Console.WriteLine("Document ID: {0} , Sentiment Score: {1:0.00}", document.Id, document.Score);
            }

            double res = 0d;
            var item = result3.Documents.FirstOrDefault();
            if (item != null)
            {
                res = item.Score.GetValueOrDefault();
            }
            return res;


        }     
        
    }
}

