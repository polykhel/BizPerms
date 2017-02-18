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
    public class RequirementController : Controller
    {
        // GET: Requirement
        public ActionResult Index()
        {
            ViewBag.statuses = StatusData.ListAll();
            List<Requirement> model = RequirementData.ListAll();
            return View(model);
        }

        // GET: Add Requirement
        public ActionResult Add()
        {
            ViewBag.statuses = StatusData.ListAll();
            return View();
        }

        // POST: Add Requirement
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Requirement model)
        {
            model.CreatedDate = DateTime.Now;
            bool result = RequirementData.Add(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Delete Requirement
        public ActionResult Delete(Guid id)
        {
            ViewBag.statuses = StatusData.ListAll();
            Requirement model = RequirementData.GetById(id);
            return View(model);
        }

        // POST: Delete Requirement
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Requirement model)
        {
            bool result = RequirementData.Delete(model.UniqueId.ToString());
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Edit Requirement
        public ActionResult Edit(Guid id)
        {
            ViewBag.statuses = StatusData.ListAll();
            Requirement model = RequirementData.GetById(id);
            return View(model);
        }

        // POST: Edit Requirement
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Requirement model)
        {
            bool result = RequirementData.Edit(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}