using System;
using System.Collections.Generic;
using System.Web.Mvc;
using G4.BizPermit.Entities;
using G4.BizPermit.Dal;
using BizPerms.Helpers;
using System.Data.Entity;
using System.Linq;

namespace G4.BizPermit.Web.Controllers
{
    [AccessDeniedAuthorize(Roles = "Admin")]
    public class JsonController : Controller
    {
        // GET: Json
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Fees()
        {
            DB db = new DB();
            List<Fee> fees = db.Fees.ToList();
            return Json(new { fees, isSuccess = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NewFees()
        {
            DB db = new DB();
            List<Fee> fees = db.Fees.Include(x => x.Status).Where(x => x.StatusId != 2).ToList();
            return Json(new { fees, isSuccess = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RenewFees()
        {
            DB db = new DB();
            List<Fee> fees = db.Fees.Include(x => x.Status).Where(x => x.StatusId != 1).ToList();
            return Json(new { fees, isSuccess = true }, JsonRequestBehavior.AllowGet);
        }

        // GET: Barangays
        public ActionResult Barangays()
        {
            List<Barangay> bars = BarangayData.ListAll();
            return Json(new { bars, isSuccess = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cities()
        {
            List<City> cits = CitiesData.ListAll();
            return Json(new { cits, isSuccess = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Districts()
        {
            List<District> dis = DistrictData.ListAll();
            return Json(new { dis, isSuccess = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Streets()
        {
            List<Street> sts = StreetData.ListAll();
            return Json(new { sts, isSuccess = true }, JsonRequestBehavior.AllowGet);
        }
    }
}