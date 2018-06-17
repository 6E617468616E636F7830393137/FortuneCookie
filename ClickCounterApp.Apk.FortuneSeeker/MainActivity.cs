using Android.App;
using Android.Widget;
using Android.OS;
using System.Net;
using Newtonsoft.Json;
using Android.Support.V7.App;
using Android.Content;
using System;

namespace ClickCounterApp.Apk.FortuneSeeker
{
    [Activity(Label = "Fortune Seeker", Theme = "@style/YinYangTheme.Splash")]
    public class MainActivity : AppCompatActivity
    {
        private string previousId;
        private string currentId;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);            

            previousId = "0";
            
            Button button = FindViewById<Button>(Resource.Id.button1);
            TextView authorQuote = FindViewById<TextView>(Resource.Id.fortuneTextAuthor);
            TextView textQuote = FindViewById<TextView>(Resource.Id.fortuneTextQuote);
            textQuote.Text = "Started...";
            var model = DownloadPage();
            authorQuote.Text = model.Type;
            textQuote.Text = model.Message;

            //var task = DownloadPageAsync();
            //task.Wait();
            //text.Text = task.Result;

            button.Click += delegate
            {
                var result = DownloadPage();
                authorQuote.Text = result.Type;
                textQuote.Text = result.Message;
            };
        }
        WebModels.Fortune.Messages DownloadPage()
        {
            string page = "http://www.thecomputerscientist.net/fortuneapi/api/random";

            try
            {
                using (WebClient content = new WebClient())
                {
                    string result = "";
                    WebModels.Fortune.Messages model;
                    do
                    {
                        // ... Read the string.
                        result = content.DownloadString(page);
                        model = JsonToObject(result);
                        currentId = model.Id;
                    } while (previousId == currentId);
                    previousId = currentId;
                    model.Type = $"{model.Type} States ~ ";
                    return model;//$"{model.Type} states:\r\n{model.Message}";
                }
            }
            catch (Exception)
            {
                return new WebModels.Fortune.Messages
                {
                    Type = "Buddah Claims ~",
                    Message = "You are not connected at this time, try again!"
                };
            }
        }
        WebModels.Fortune.Messages JsonToObject(string data)
        {            
            return JsonConvert.DeserializeAnonymousType<WebModels.Fortune.Messages>(data, new WebModels.Fortune.Messages());            
        }
        
    }    

}

