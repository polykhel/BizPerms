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
    public class BusinessRecordController : Controller
    {
        // GET: Business Record
        public ActionResult Index()
        {
            ViewBag.GetNew = RequirementData.GetNew();
            ViewBag.GetRenew = RequirementData.GetRenew();
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
            ViewBag.Requirements = RequirementData.GetNew();
            return View();
        }

        // POST: Add Business Record
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BusinessRecord model, string[] selectedReqs)
        {
            DB context = new DB();
            List<Requirement> newReqs = context.Requirements.Include(x => x.Status).Where(x => x.StatusId != 2).ToList();
            if (selectedReqs == null)
            {
                model.Requirements = new List<Requirement>();
            }
            var selectedReqsHS = new HashSet<string>(selectedReqs);
            //var businessRecords = new HashSet<int>(BusinessRecordData.GetAllReqId(model.UniqueId));
            foreach (var reqs in newReqs)
            {
                if (selectedReqsHS.Contains(reqs.Id.ToString()))
                {
                    //if (!businessRecords.Contains(reqs.Id))
                    //{
                    //    model.Requirements.Add(reqs);
                    //}
                    model.Requirements.Add(reqs);
                }
                //else
                //{
                //    if (businessRecords.Contains(reqs.Id))
                //    {
                //        model.Requirements.Remove(reqs);
                //    }
                //}
            }
            model.UniqueId = Guid.NewGuid();
            context.BusinessRecords.Add(model);
            try
            {
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete Business Record
        public ActionResult Delete(string id)
        {
            ViewBag.businessowners = BusinessOwnerData.ListAll();
            ViewBag.businessdetails = BusinessDetailData.ListAll();
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

            return View(model);
        }

        // GET: Edit Business Record
        public ActionResult Edit(string id)
        {
            ViewBag.businessowners = BusinessOwnerData.ListAll();
            ViewBag.businessdetails = BusinessDetailData.ListAll();
            ViewBag.provinces = ProvincesData.ListAll();
            ViewBag.cities = CitiesData.ListAll();
            ViewBag.districts = DistrictData.ListAll();
            ViewBag.barangays = BarangayData.ListAll();
            ViewBag.streets = StreetData.ListAll();
            ViewBag.businesstype = BusinessTypeData.ListAll();
            BusinessRecord model = BusinessRecordData.GetById(id);
            ViewBag.businessRecords = new HashSet<int>(model.Requirements.Select(i => i.Id));
            if (model.BusinessDetail.isNew)
            {
                ViewBag.Requirements = RequirementData.GetNew();
            } else
            {
                ViewBag.Requirements = RequirementData.GetRenew();
            }
            return View(model);
        }

        // POST: Edit Business Record
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BusinessRecord model, string[] selectedReqs, string isNew)
        {
            DB context = new DB(); List<Requirement> nrReqs;
            if (isNew == "true")
            {
                nrReqs = context.Requirements.Include(x => x.Status).Where(x => x.StatusId != 2).ToList();
            }
            else
            {
                nrReqs = context.Requirements.Include(x => x.Status).Where(x => x.StatusId != 1).ToList();
            }
            if (selectedReqs == null)
            {
                model.Requirements = new List<Requirement>();
            }
            var selectedReqsHS = new HashSet<string>(selectedReqs);
            BusinessRecord _obj = context.BusinessRecords.Include(x => x.Requirements).Where(o => o.UniqueId == model.UniqueId).SingleOrDefault();
            var businessRecords = new HashSet<int>(_obj.Requirements.Select(i => i.Id));
            foreach (var reqs in nrReqs)
            {
                if (selectedReqsHS.Contains(reqs.Id.ToString()))
                {
                    if (!businessRecords.Contains(reqs.Id))
                    {
                        model.Requirements.Add(reqs);
                    }
                    model.Requirements.Add(reqs);
                }
                else
                {
                    if (businessRecords.Contains(reqs.Id))
                    {
                        model.Requirements.Remove(reqs);
                    }
                }
            }
            _obj.BusinessName = model.BusinessName;
            _obj.BusinessDetailId = model.BusinessDetailId;
            _obj.OwnerId = model.OwnerId;
            _obj.StartDate = model.StartDate.Date;
            _obj.ContactNo = model.ContactNo;
            _obj.FaxNo = model.FaxNo;
            _obj.ProvinceId = model.ProvinceId;
            _obj.CityId = model.CityId;
            _obj.DistrictId = model.DistrictId;
            _obj.BarangayId = model.BarangayId;
            _obj.StreetId = model.StreetId;
            _obj.StreetNo = model.StreetNo;
            _obj.BlockNo = model.BlockNo;
            _obj.Address = model.Address;
            _obj.BuildingName = model.BuildingName;
            _obj.FloorNo = model.FloorNo;
            _obj.isActive = model.isActive;
            _obj.BusinessTypeId = model.BusinessTypeId;
            _obj.isRetired = model.isRetired;
            _obj.Requirements = model.Requirements;
            try
            {
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}