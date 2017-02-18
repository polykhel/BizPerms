using BizPerms.Helpers;
using G4.BizPermit.Dal;
using G4.BizPermit.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace G4.BizPermit.Web.Controllers
{
    [AccessDeniedAuthorize(Roles = "Admin")]
    public class FeeController : Controller
    {
        // GET: Fee
        public ActionResult Index()
        {
            ViewBag.status = StatusData.ListAll();
            List<Fee> model = new List<Fee>();
            model = FeeData.ListAll();
            return View(model);
        }

        public ActionResult Add()
        {
            ViewBag.Status = StatusData.ListAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Fee fee)
        {
            bool result = FeeData.Add(fee);
            if (result)
            {
                return RedirectToAction("Index");
            }else
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            ViewBag.Status = StatusData.ListAll();
            Fee fee = FeeData.GetById(id);
            return View(fee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fee fee)
        {
            bool result = FeeData.Edit(fee);
            if (result)
            {
                return RedirectToAction("Index");
            }else
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            Fee fee = FeeData.GetById(id);
            return View(fee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Fee fee)
        {
            bool result = FeeData.Delete(fee.UniqueId.ToString());
            if (result)
            {
                return RedirectToAction("Index");
            }else
            {
                return View();
            }
        }
    }
}