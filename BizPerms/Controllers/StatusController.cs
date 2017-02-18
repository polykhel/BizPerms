using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G4.BizPermit.Dal;
using G4.BizPermit.Entities;
using BizPerms.Helpers;

namespace G4.BizPermit.Web.Controllers
{
    [AccessDeniedAuthorize(Roles = "Admin")]
    public class StatusController : Controller
    {
        // GET: Status
        public ActionResult Index()
        {
            List<Status> model = StatusData.ListAll();
            return View(model);
        }

        // GET: Add Status
        public ActionResult Add()
        {
            return View();
        }

        // POST: Add Status
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Status model)
        {
            model.CreatedDate = DateTime.Now;
            bool result = StatusData.Add(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Delete Status
        public ActionResult Delete(Guid id)
        {
            Status model = StatusData.GetById(id);
            return View(model);
        }

        // POST: Delete Status
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Status model)
        {
            bool result = StatusData.Delete(model.UniqueId.ToString());
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Edit Status
        public ActionResult Edit(Guid id)
        {
            Status model = StatusData.GetById(id);
            return View(model);
        }

        // POST: Edit Status
        [HttpPost]
        public ActionResult Edit(Status model)
        {
            bool result = StatusData.Edit(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}