using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCounterApp.Business.Download.Fortune
{
    public class GenericRequest
    {
        // Declaration
        private readonly IGenericRequest _request;
        // Constructor
        public GenericRequest(IGenericRequest concreteImplementation)
        {
            _request = concreteImplementation;
        }
        public WebModels.Fortune.Messages GetFortune(string previousId)
        {
            return _request.GetFortune(previousId);
        }
    }
}
