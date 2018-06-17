using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClickCounterApp.Business.Download.Fortune.Transactions
{
    internal class Request
    {
        internal WebModels.Fortune.Messages Execute(string previousId)
        {
            string page = "http://www.thecomputerscientist.net/fortuneapi/api/random";
            string currentId = "";

            using (HttpClient content = new HttpClient())
            {
                string result = "";
                WebModels.Fortune.Messages model;
                do
                {
                    // ... Read the string.
                    result = content.GetStringAsync(page).Result;
                    model = (WebModels.Fortune.Messages)new Serializers.Json.Transform(new Serializers.Json.Transaction.Execute()).Execute(result, new WebModels.Fortune.Messages());
                    currentId = model.Id;
                } while (previousId == currentId);
                previousId = currentId;
                model.Type = $"{model.Type} States ~ ";
                return model;//$"{model.Type} states:\r\n{model.Message}";
            }
        }
    }
}
