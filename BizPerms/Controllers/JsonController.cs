using System;
using System.Collections.Generic;
using System.Web.Mvc;
using G4.BizPermit.Entities;
using G4.BizPermit.Dal;
using BizPerms.Helpers;

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