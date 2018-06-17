using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClickCounterApp.Tests.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("= = = = = = Api Fortune Test = = = = = =");
            //Task t = new Task(DownloadPageAsync);
            
            //t.Start();
            Console.WriteLine("Downloading page...");
            var x = (DownloadPageAsync());
            x.Wait();
            var data = (Entities.Fortune.Messages)new Business.Serializers.Json.Transform(new Business.Serializers.Json.Transaction.Execute()).Execute(x.Result, new Entities.Fortune.Messages());

            //Console.WriteLine(x.Result);
            Console.ReadLine();
        }
        static async Task<string> DownloadPageAsync()
        {
            // ... Target page.
            string page = "http://localhost:55376/api/Random";

            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();

                // ... Display the result.
                //if (result != null &&
                //    result.Length >= 50)
                //{
                //    Console.WriteLine(result.Substring(0, 50) + "...");
                //}
                return result;
            }
        }
    }
}
