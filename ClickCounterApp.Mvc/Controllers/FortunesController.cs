using ClickCounterApp.Entities.Fortune;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ClickCounterApp.Mvc.Controllers
{
    public class FortunesController : Controller
    {
        private int itemsPerPage;
        private IEnumerable<Messages> data;

        // CONSTRUCTOR
        public FortunesController()
        {
            //System.Web.HttpContext.Current.Session["pageId"] = 0;

            var temp = new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).GetEntryCount() / Convert.ToDouble(ConfigurationManager.AppSettings["ItemsPerPage"]);
            var intValue = (int)temp;
            if (intValue == temp)
            {
                System.Web.HttpContext.Current.Session["pageTotal"] = intValue;
            }
            else
            {
                System.Web.HttpContext.Current.Session["pageTotal"] = intValue + 1;
            }
            itemsPerPage = Convert.ToInt32(ConfigurationManager.AppSettings["ItemsPerPage"]);
            
        }

        // GET: Fortunes
        //public ActionResult Main(int? id, bool Descending = true)
        public ActionResult Main(int? id)
        {
            if(WebModels.Fortune.Session.descending == null)
                WebModels.Fortune.Session.descending = true;
            //var data = new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).Get();
            data = SortOrder((bool)WebModels.Fortune.Session.descending);
            if (WebModels.Fortune.Session.CurrentPage != null)
            {
                //System.Web.HttpContext.Current.Session["pageId"] = WebModels.Fortune.Session.CurrentPage;
                id = WebModels.Fortune.Session.CurrentPage;
                WebModels.Fortune.Session.CurrentPage = null;
            }
            else
            {
                WebModels.Fortune.Session.NextPrevPage = id;
                //WebModels.Fortune.Session.CurrentPage = id;
                //System.Web.HttpContext.Current.Session["pageId"] = id == null || (int)id <= 0 ? 0 : (int)id - 1;
            }
            return View(data.Skip(id == null ? default(int) : ((int)id - 1) * itemsPerPage).Take(itemsPerPage));
            //return View("~/Views/Fortunes/Main.cshtml", data.Skip(id == null ? default(int) : ((int)id - 1) * itemsPerPage).Take(itemsPerPage));
        }
        public ActionResult Next()
        {
            data = SortOrder((bool)WebModels.Fortune.Session.descending);

            int? id;
            if (WebModels.Fortune.Session.NextPrevPage == null || WebModels.Fortune.Session.NextPrevPage == 0)
            {
                WebModels.Fortune.Session.NextPrevPage = 2;
                id = 2;
            }
            else
            {
                WebModels.Fortune.Session.NextPrevPage++;
                id = WebModels.Fortune.Session.NextPrevPage;
            }
            return PartialView("~/Views/Fortunes/Main.cshtml", data.Skip(id == null ? default(int) : ((int)id - 1) * itemsPerPage).Take(itemsPerPage));
            //return View(data.Skip(id == null ? default(int) : ((int)id - 1) * itemsPerPage).Take(itemsPerPage));
        }
        public PartialViewResult Prev()
        {
            //var data = new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).Get();
            data = SortOrder((bool)WebModels.Fortune.Session.descending);
            int? id;
            if (WebModels.Fortune.Session.NextPrevPage == null || WebModels.Fortune.Session.NextPrevPage == 0)
            {
                WebModels.Fortune.Session.NextPrevPage = 0;
                id = 1;
            }
            else
            {
                WebModels.Fortune.Session.NextPrevPage--;
                id = WebModels.Fortune.Session.NextPrevPage;
            }
            return PartialView("~/Views/Fortunes/Main.cshtml", data.Skip(id == null ? default(int) : ((int)id - 1) * itemsPerPage).Take(itemsPerPage));
            //return View(data.Skip(id == null ? default(int) : ((int)id - 1) * itemsPerPage).Take(itemsPerPage));
        }
        [HttpPost]
        public ActionResult OrderSelect(string Data)
        {
            int? id = 0;
            if (Data == "1")
                WebModels.Fortune.Session.descending = true;
            else
                WebModels.Fortune.Session.descending = false;
            //IEnumerable<Messages> data = SortOrder(descending);
            data = SortOrder((bool)WebModels.Fortune.Session.descending);
            if (WebModels.Fortune.Session.CurrentPage != null)
            {
                //System.Web.HttpContext.Current.Session["pageId"] = WebModels.Fortune.Session.CurrentPage;
                id = WebModels.Fortune.Session.CurrentPage;
                WebModels.Fortune.Session.CurrentPage = null;
            }
            else
            {
                WebModels.Fortune.Session.NextPrevPage = id;
                //WebModels.Fortune.Session.CurrentPage = id;
                //System.Web.HttpContext.Current.Session["pageId"] = id == null || (int)id <= 0 ? 0 : (int)id - 1;
            }
            //return View(data.Skip(id == null ? default(int) : ((int)id - 1) * itemsPerPage).Take(itemsPerPage));
            //return RedirectToAction("Main");
            return PartialView("~/Views/Fortunes/Main.cshtml", data.Skip(id == null ? default(int) : ((int)id - 1) * itemsPerPage).Take(itemsPerPage));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string type, string message, string luckyNumbers)
        {
            if (message != null)
            {
                //db.Entry(movie).State = EntityState.Modified;
                //db.SaveChanges();
                var data = new Messages
                {
                    CreatedDate = DateTime.Now,
                    Message = message,
                    LuckyNumbers = luckyNumbers,
                    Type = type
                };
                new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).Insert(data);
                SetCurrentPage(data.Id);
                return RedirectToAction("Main");
            }

            return View(message);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).GetById(id);
            SetCurrentPage(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return PartialView(data);
        }
        // GET: Fortunes/Edit/{Id}
        // For finding data to edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).GetById(id);
            SetCurrentPage(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return PartialView(data);
        }
        // POST: Fortunes/Edit
        // For updating content 
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "Id,CreatedDate,Message,LuckyNumbers,Type")]
        public ActionResult Edit(int id, DateTime createdDate, string type, string message, string luckyNumbers)
        {
            if (message != null)
            {
                //db.Entry(movie).State = EntityState.Modified;
                //db.SaveChanges();
                var data = new Messages
                {
                    Id = id,
                    CreatedDate = createdDate,
                    Message = message,
                    LuckyNumbers = luckyNumbers,
                    Type = type
                };
                new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).Update(data);
                return RedirectToAction("Main");
            }
            return PartialView(message);
        }
        //Setting current page based on current item selected and items per page.
        private void SetCurrentPage(int? id)
        {
            var tempVar = id / Convert.ToDouble(itemsPerPage);
            if (tempVar != (id / itemsPerPage))
                WebModels.Fortune.Session.CurrentPage = (id / itemsPerPage) + 1;
            else
                WebModels.Fortune.Session.CurrentPage = (id / itemsPerPage);
        }
        private IEnumerable<Messages> SortOrder(bool IsDescending)
        {
            if (IsDescending)
            {
                return new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).Get().OrderByDescending(x => x.Id);
            }
            else
            {
                //return new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).Get();
                return new Business.UnitOfWork.GenericRequest<Messages>(new Business.UnitOfWork.Transaction<Messages>.ExecuteDb()).Query("SELECT * FROM [dbo].[Messages]");
            }
        }
        

    }
}