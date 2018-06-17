using ClickCounterApp.Entities.Fortune;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Log = Log4net.Helper.Logging.Logger;
namespace ClickCounterApp.Api.Controllers
{
    public class FortuneSeekerController : ApiController
    {
        [Route("api/GetFortunes")]
        [HttpPost]
        public IHttpActionResult GetFortunes()
        {
            IEnumerable<Messages> data = (new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).Get());
            var output = (List<Messages>)Convert.ChangeType(data, typeof(List<Messages>));
            return Ok(output);
        }
        //[Route("api/Add")]
        //[Route("api/Update")]
        [Route("api/Random")]
        [HttpGet]
        public IHttpActionResult Random()
        {
            Random random = new System.Random();
            var count = new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).GetEntryCount();
            int interator = 0;
            //Log.Debug($"Generating Random Value - Count = {count}");
            //int current = 0;
            //for (int i = 0; i < 100; i++)
            //{
            //    do {
                    
            interator = random.Next(1, count+1);
            //    }
            //    while (interator == current);
            //    current = interator;
            //    Log.Debug($"Next Random = {interator}");
            //}
            //Log.Debug($"Generating Random Value - Random Value = {count}");
            return Ok(new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).GetById(interator));
        }
    }
}
