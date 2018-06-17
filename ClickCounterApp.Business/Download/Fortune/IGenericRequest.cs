using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCounterApp.Business.Download.Fortune
{
    public interface IGenericRequest
    {
        WebModels.Fortune.Messages GetFortune(string previousId);
    }
}
