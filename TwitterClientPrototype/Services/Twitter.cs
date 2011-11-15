using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using Newtonsoft.Json;
using TwitterClientPrototype.Model;

namespace TwitterClientPrototype.Services
{
    public class Twitter
    {
        private readonly WebClient wc;
        private string requestString =
            "https://api.twitter.com/1/statuses/user_timeline.json?count=10&include_entities=true&screen_name=vintharas";

        private Action<IEnumerable<Tweet>> refreshTweetsInUI;

        // Ctor
        public Twitter()
        {
            // Create the WebClient and associate a handler with the OpenReadCompleted event.
            wc = new WebClient();
            wc.DownloadStringCompleted += wc_DownloadStringCompleted;
        }

        public void RefreshTweets(Action<IEnumerable<Tweet>> refreshTweetsInUI)
        {
            this.refreshTweetsInUI = refreshTweetsInUI;
            wc.DownloadStringAsync(new Uri(requestString));
        }

        private void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var tweets = JsonConvert.DeserializeObject<IEnumerable<Model.Tweet>>(e.Result);
            refreshTweetsInUI(tweets);
        }

    }

}