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
        public IHttpActionResult Random(int id)
        {
            int interator = 0;
            var count = new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).GetEntryCount();
            if (id == 0 )
            {
                Random random = new System.Random();
                interator = random.Next(1, count + 1);
            }
            else
            {
                interator = id % count;
            }
            
            return Ok(new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).GetById(interator));
        }
        [Route("api/Random")]
        [HttpPost]
        public IHttpActionResult PostRandom()
        {
            Random random = new System.Random();
            var count = new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).GetEntryCount();
            int interator = 0;           

            interator = random.Next(1, count + 1);            
            return Ok(new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).GetById(interator));
        }
        [Route("api/Random")]
        [HttpPut]
        public IHttpActionResult PutRandom()
        {
            Random random = new System.Random();
            var count = new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).GetEntryCount();
            int interator = 0;

            interator = random.Next(1, count + 1);
            return Ok(new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).GetById(interator));
        }
        [Route("api/Random")]
        [HttpPatch]
        public IHttpActionResult PatchRandom()
        {
            Random random = new System.Random();
            var count = new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).GetEntryCount();
            int interator = 0;

            interator = random.Next(1, count + 1);
            return Ok(new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).GetById(interator));
        }
    }
}
