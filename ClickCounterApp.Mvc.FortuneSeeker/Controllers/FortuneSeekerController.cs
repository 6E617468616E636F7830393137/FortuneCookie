using System.Web.Mvc;

namespace ClickCounterApp.Mvc.FortuneSeeker.Controllers
{
    public class FortuneSeekerController : Controller
    {
        private string previousId;
        // GET: FortuneSeeker
        public ActionResult Index()
        {
            var model = new Business.Download.Fortune.GenericRequest(new Business.Download.Fortune.Transaction.Execute()).GetFortune(previousId);
            previousId = model.Id;
            return View(model);
        }
        [HttpPost]
        public ActionResult Message(WebModels.Fortune.Messages previousId)
        {

            return PartialView("~/Views/FortuneSeeker/Partials/MessageUpdate.cshtml",
                new Business.Download.Fortune.GenericRequest(new Business.Download.Fortune.Transaction.Execute()).GetFortune(previousId.Id));
        }
    }
}