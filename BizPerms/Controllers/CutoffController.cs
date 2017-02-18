using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G4.BizPermit.Entities;
using G4.BizPermit.Dal;
using BizPerms.Helpers;

namespace G4.BizPermit.Web.Controllers
{
    [AccessDeniedAuthorize(Roles = "Admin")]
    public class CutoffController : Controller
    {
        // GET: Cutoff
        public ActionResult Index()
        {
            List<Cutoff> model = new List<Cutoff>();
            model = CutoffData.ListAll();
            return View(model);


            //ViewBag.Cutoffs = CutoffData.ListAll();
            //List<Cutoff> model = new List<Cutoff>();
            //model = CutoffData.ListAll();
            //return View(model);
        }
        public ActionResult Add()
        {
            ViewBag.Cutoffs = CutoffData.ListAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Cutoff cutoff)
        {
            cutoff.CreatedDate = DateTime.Now;
            bool result = CutoffData.Add(cutoff);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            ViewBag.Cutoffs = CutoffData.ListAll();
            Cutoff cutoff = CutoffData.GetById(id);
            return View(cutoff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cutoff cutoff)
        {
            bool result = CutoffData.Edit(cutoff);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            ViewBag.Cutoffs = CutoffData.ListAll();
            Cutoff cutoff = CutoffData.GetById(id);
            return View(cutoff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Cutoff cutoff)
        {
            bool result = CutoffData.Delete(cutoff.UniqueId.ToString());
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}