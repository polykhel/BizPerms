using G4.BizPermit.Dal;
using G4.BizPermit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace G4.BizPermit.Web.Controllers
{
    public class BankController : Controller
    {
        // GET: Bank
        public ActionResult Index()
        {
            List<Bank> model = BankData.ListAll();
            return View(model);
        }

        // GET: Add Bank Record
        public ActionResult Add()
        {
            return View();    
        }

        // POST: Add 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Bank Model)
        {
            bool result = BankData.Add(Model);
            if (result)
            {         
                {
                    return RedirectToAction("Index");
                }
               
            }
            return View();
        }

        public ActionResult Edit(string id)
        {
            ViewBag.businesslines = BusinessLineData.ListAll();
            Bank model = BankData.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Bank model)
        {
            bool result = BankData.Edit(model);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }



        //Delete
        // GET: Delete Bank Record
        public ActionResult Delete(string id)
        {
            //ViewBag.banks = BankData.ListAll();
            //            ViewBag.businessnatures = BusinessNatureData.ListAll();
            //          ViewBag.provinces = ProvincesData.ListAll();
            //            ViewBag.cities = CitiesData.ListAll();
            //            ViewBag.districts = DistrictData.ListAll();
            //            ViewBag.barangays = BarangayData.ListAll();
            //            ViewBag.streets = StreetData.ListAll();
            //            ViewBag.businesstype = BusinessTypeData.ListAll();
            //            BusinessRecord model = BusinessRecordData.GetById(id);
                        Bank model = BankData.GetById(id);

            return View(model);
        }


        // POST: Delete Bank Record
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Bank model)
        {
            bool result = BankData.Delete(model.UniqueId.ToString());
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}