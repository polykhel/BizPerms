using System;
using System.Collections.Generic;
using System.Linq;
using G4.BizPermit.Entities;
using System.Data.Entity;

namespace G4.BizPermit.Dal
{
    public class BusinessDetailData
    {
        public static List<BusinessDetail> ListAll()
        {
            using (DB context = new DB())
            {
                return context.BusinessDetails.Include(x => x.BusinessLine).ToList();
            }
        }
        public static bool Add(BusinessDetail obj)
        {
            using (DB context = new DB())
            {
                obj.UniqueId = Guid.NewGuid();
                context.BusinessDetails.Add(obj);
                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public static bool Edit(BusinessDetail obj)
        {
            using (DB context = new DB())
            {
                BusinessDetail _obj = context.BusinessDetails.Where(o => o.UniqueId == obj.UniqueId).SingleOrDefault();
                _obj.BusinessLineId = obj.BusinessLineId;
                _obj.BirthDate = obj.BirthDate;
                _obj.Capital = obj.Capital;
                _obj.Gross = obj.Gross;
                _obj.isNew = obj.isNew;
                _obj.lastPayDate = obj.lastPayDate;
               
                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }

                return true;
            }
        }

        public static bool Delete(string id)
        {
            using (DB context = new DB())
            {
                BusinessDetail obj = context.BusinessDetails.Where(o => o.UniqueId == new Guid(id)).SingleOrDefault();
                context.BusinessDetails.Remove(obj);
                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }

                return true;
            }
        }

        public static BusinessDetail GetById(string id)
        {
            using (DB context = new DB())
            {
                BusinessDetail obj = context.BusinessDetails.Where(o => o.UniqueId == new Guid(id)).SingleOrDefault();
                return obj;
            }
        }
    }
}


