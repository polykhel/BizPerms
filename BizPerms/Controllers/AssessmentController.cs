using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using G4.BizPermit.Entities;
using G4.BizPermit.Dal;
using BizPerms.Models;

namespace BizPerms.Controllers
{
    public class AssessmentController : Controller
    {
        // GET: Assessment
        public ActionResult Index()
        {
            DB db = new DB();
            var model = new BusinessViewModel();
            model.BusinessNames = db.BusinessRecords.Select(p => new SelectListItem
            {
                Value = "Assessment/Business/" + p.UniqueId,
                Text = p.BusinessName
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Business(string id)
        {
            DB db = new DB();
            var model = new AssessmentViewModel();
            BusinessRecord record = BusinessRecordData.GetById(id);
            model.Id = record.Id;
            int newReqs = db.Requirements.Where(x => x.StatusId != 2).Count();
            int renewReqs = db.Requirements.Where(x => x.StatusId != 1).Count();
            model.BusinessName = record.BusinessName;
            model.Address = record.Address;
            model.isNew = record.BusinessDetail.isNew;
            model.lastDatePaid = record.BusinessDetail.lastPayDate;
            model.OwnerName = record.BusinessOwner.FirstName + " " + record.BusinessOwner.LastName;
            if (model.isNew)
            {
                if (record.Requirements.Count == newReqs)
                {
                    model.completeRequirements = true;
                } else
                {
                    model.completeRequirements = false;
                }
            } else
            {
                if (record.Requirements.Count == renewReqs)
                {
                    model.completeRequirements = true;
                }
                else
                {
                    model.completeRequirements = false;
                }
            }
            //DateTime cutOffFirst = DateTime.ParseExact("2017-03-31", "yyyy-MM-dd",
            //                          System.Globalization.CultureInfo.InvariantCulture);
            //DateTime cutOffSecond = DateTime.ParseExact("2017-06-30", "yyyy-MM-dd",
            //                          System.Globalization.CultureInfo.InvariantCulture);
            //DateTime cutOffThird = DateTime.ParseExact("2017-09-30", "yyyy-MM-dd",
            //                          System.Globalization.CultureInfo.InvariantCulture);
            //DateTime cutOffFourth = DateTime.ParseExact("2017-12-31", "yyyy-MM-dd",
            //                          System.Globalization.CultureInfo.InvariantCulture);
            model.isCollected = record.isCollected;
            if (/*model.lastDatePaid <= cutOffFirst */ model.isCollected <= 0) //disabled check because this is always true until March 31, 2017. lastpaiddate will always be before 03/31 because it is updated by DateTime.NOW
            {
                model.isFirst = false;
                model.isSecond = false;
                model.isThird = false;
                model.isFourth = false;
                model.lastQuarterPaid = "";
            } else if (/*(model.lastDatePaid > cutOffFirst && model.lastDatePaid <= cutOffSecond)*/ model.isCollected == 1)
            {
                model.isFirst = true;
                model.isSecond = false;
                model.isThird = false;
                model.isFourth = false;
                model.lastQuarterPaid = "First Quarter";
            } else if (/*(model.lastDatePaid > cutOffSecond && model.lastDatePaid <= cutOffThird)*/ model.isCollected == 2)
            {
                model.isFirst = true;
                model.isSecond = true;
                model.isThird = false;
                model.isFourth = false;
                model.lastQuarterPaid = "Second Quarter";
            } else if (/*(model.lastDatePaid > cutOffThird && model.lastDatePaid <= cutOffFourth)*/ model.isCollected == 3)
            {
                model.isFirst = true;
                model.isSecond = true;
                model.isThird = true;
                model.isFourth = false;
                model.lastQuarterPaid = "Third Quarter";
            } else if (/*model.lastDatePaid > cutOffFourth &&*/ model.isCollected == 4)
            {
                model.isFirst = true;
                model.isSecond = true;
                model.isThird = true;
                model.isFourth = true;
                model.lastQuarterPaid = "Fourth Quarter";

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Business(AssessmentViewModel model)
        {
            DB db = new DB();
            BusinessRecord record = db.BusinessRecords.Find(model.Id);
            if (model.quarter == "first")
            {
                record.isAssessed = 1;
            } else if (model.quarter == "second")
            {
                record.isAssessed = 2;
            } else if (model.quarter == "third")
            {
                record.isAssessed = 3;
            } else if (model.quarter == "fourth")
            {
                record.isAssessed = 4;
            }
            db.SaveChanges();
            return Redirect("/Collection/Business/" + record.UniqueId);
        }
    }
}