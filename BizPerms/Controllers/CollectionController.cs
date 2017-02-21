using BizPerms.Models;
using G4.BizPermit.Dal;
using G4.BizPermit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;

namespace BizPerms.Controllers
{
    public class CollectionController : Controller
    {
        // GET: Collection
        public ActionResult Index()
        {
            DB db = new DB();
            var model = new BusinessViewModel();
            model.BusinessNames = db.BusinessRecords.Select(p => new SelectListItem
            {
                Value = "Collection/Business/" + p.UniqueId,
                Text = p.BusinessName
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Business(string id)
        {
            DB db = new DB();
            var model = new CollectionViewModel();
            BusinessRecord record = BusinessRecordData.GetById(id);
            model.Id = record.Id;
            model.BusinessName = record.BusinessName;
            model.OwnerName = record.BusinessOwner.FirstName + " " + record.BusinessOwner.LastName;
            model.quarter = record.isAssessed;
            model.isNew = record.BusinessDetail.isNew;
            model.lastDatePaid = record.BusinessDetail.lastPayDate;
            //DateTime cutOffFirst = DateTime.ParseExact("2017-03-31", "yyyy-MM-dd",
            //                           System.Globalization.CultureInfo.InvariantCulture);
            //DateTime cutOffSecond = DateTime.ParseExact("2017-06-30", "yyyy-MM-dd",
            //                          System.Globalization.CultureInfo.InvariantCulture);
            //DateTime cutOffThird = DateTime.ParseExact("2017-09-30", "yyyy-MM-dd",
            //                          System.Globalization.CultureInfo.InvariantCulture);
            //DateTime cutOffFourth = DateTime.ParseExact("2017-12-31", "yyyy-MM-dd",
            //                          System.Globalization.CultureInfo.InvariantCulture);
            if (/*model.lastDatePaid <= cutOffFirst */ record.isCollected <= 0) //disabled check because this is always true until March 31, 2017. lastpaiddate will always be before 03/31 because it is updated by DateTime.NOW
            {
                model.lastQuarterPaid = 0;
            }
            else if (/*(model.lastDatePaid > cutOffFirst && model.lastDatePaid <= cutOffSecond)*/ record.isCollected == 1)
            {
                model.lastQuarterPaid = 1;
            }
            else if (/*(model.lastDatePaid > cutOffSecond && model.lastDatePaid <= cutOffThird)*/ record.isCollected == 2)
            {
                model.lastQuarterPaid = 2;
            }
            else if (/*(model.lastDatePaid > cutOffThird && model.lastDatePaid <= cutOffFourth)*/ record.isCollected == 3)
            {
                model.lastQuarterPaid = 3;
            }
            else if (/*model.lastDatePaid > cutOffFourth &&*/ record.isCollected == 4)
            {
                model.lastQuarterPaid = 4;
            }

            int orNumber = db.OfficialReceipts.Select(i => i.ORNumber).ToList().LastOrDefault();
            model.orNumber = orNumber + 1;
            model.orDate = DateTime.Now;
			//ViewBag.Banks = db.
            return View(model);
        }

        [HttpPost]
        public ActionResult Business(CollectionViewModel model)
        {
            DB db = new DB();
            BusinessRecord record = db.BusinessRecords.Find(model.Id);
            OfficialReceipt or = new OfficialReceipt();
            or.BusinessRecord = record;
            or.ORDate = model.orDate;
            or.ORNumber = model.orNumber;
            or.changeAmount = model.changeAmount;
            or.totalAmount = model.payableAmount;
            or.tenderedAmount = model.tenderedAmount;
            List<Fee> fees = new List<Fee>();
            if (model.isNew)
            {
                fees = db.Fees.Include(x => x.Status).Where(x => x.StatusId != 2).ToList();
            } else
            {
                fees = db.Fees.Include(x => x.Status).Where(x => x.StatusId != 1).ToList();
            }
            or.FeesPaid = fees;
            db.OfficialReceipts.Add(or);
            DateTime paidDate = DateTime.Now;
            record.BusinessDetail.lastPayDate = paidDate;
            record.isCollected = model.quarter;
            if (record.isCollected >= 4)
            {
                record.BusinessDetail.isNew = false;
            }
            db.SaveChanges();
            return Redirect("/Issuance/Business/" + record.UniqueId);
        }
    }
}