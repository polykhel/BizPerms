using System;
using System.Collections.Generic;
using System.Web.Mvc;
using G4.BizPermit.Entities;
using G4.BizPermit.Dal;
using BizPerms.Helpers;

namespace G4.BizPermit.Web.Controllers
{
    [AccessDeniedAuthorize(Roles = "Admin")]
    public class BusinessRecordController : Controller
    {
        // GET: Business Record
        public ActionResult Index()
        {
            List<BusinessRecord> model = new List<BusinessRecord>();
            model = BusinessRecordData.ListAll();
            return View(model);
        }

        // GET: Add Business Record
        public ActionResult Add()
        {
            ViewBag.businessowners = BusinessOwnerData.ListAll();
            ViewBag.businessdetails = BusinessDetailData.ListAll();
            ViewBag.provinces = ProvincesData.ListAll();
            ViewBag.cities = CitiesData.ListAll();
            ViewBag.districts = DistrictData.ListAll();
            ViewBag.barangays = BarangayData.ListAll();
            ViewBag.streets = StreetData.ListAll();
            ViewBag.businesstype = BusinessTypeData.ListAll();
            return View();
        }

        // POST: Add Business Record
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BusinessRecord model)
        {
            bool result = BusinessRecordData.Add(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Delete Business Record
        public ActionResult Delete(string id)
        {
            ViewBag.businessowners = BusinessOwnerData.ListAll();
            ViewBag.businessnatures = BusinessNatureData.ListAll();
            ViewBag.provinces = ProvincesData.ListAll();
            ViewBag.cities = CitiesData.ListAll();
            ViewBag.districts = DistrictData.ListAll();
            ViewBag.barangays = BarangayData.ListAll();
            ViewBag.streets = StreetData.ListAll();
            ViewBag.businesstype = BusinessTypeData.ListAll();
            BusinessRecord model = BusinessRecordData.GetById(id);
            return View(model);
        }

        // POST: Delete Business Record
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(BusinessRecord model)
        {
            bool result = BusinessRecordData.Delete(model.UniqueId.ToString());
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Edit Business Record
        public ActionResult Edit(string id)
        {
            ViewBag.businessowners = BusinessOwnerData.ListAll();
            ViewBag.businessnatures = BusinessNatureData.ListAll();
            ViewBag.provinces = ProvincesData.ListAll();
            ViewBag.cities = CitiesData.ListAll();
            ViewBag.districts = DistrictData.ListAll();
            ViewBag.barangays = BarangayData.ListAll();
            ViewBag.streets = StreetData.ListAll();
            ViewBag.businesstype = BusinessTypeData.ListAll();
            BusinessRecord model = BusinessRecordData.GetById(id);
            return View(model);
        }

        // POST: Edit Business Record
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BusinessRecord model)
        {
            bool result = BusinessRecordData.Edit(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}