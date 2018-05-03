﻿using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToTwitter;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{ 
    public static class TwitterAdapter
    {
        public static string ConsumerKey;

        public static string ConsumerSecret;

        public static async Task<string> SearchAsync(string query)
        {
            var auth = new ApplicationOnlyAuthorizer()
            {
                CredentialStore =
                    new SessionStateCredentialStore()
                    {
                        ConsumerKey = ConsumerKey,
                        ConsumerSecret = ConsumerSecret,
                    }
            };

            await auth.AuthorizeAsync();

            var twitterCtx = new TwitterContext(auth);

            var searchResults =
                (from search in twitterCtx.Search
                 where search.Type == SearchType.Search &&
                       search.Query == query
                 select search.Statuses)
                .SingleOrDefault();

            var serializedResults = "";

            if (searchResults != null && searchResults.Count > 0)
            {
                /*foreach (var result in searchResults)
                {
                    serializedResults.AppendFormat(
                        "<blockquote class=\"twitter-tweet\"><p>{0}</p><p><a href=\"{1}\"><img src=\"{2}\"/>{3}</a> - {4}</p></blockquote>",
                        result.Text,
                        result.User.Url,
                        result.User.ProfileImageUrl,
                        result.User.ScreenNameResponse,
                        result.CreatedAt);
                }*/

                serializedResults = JsonConvert.SerializeObject(searchResults);
            }

            return serializedResults;
        }
    }
}