using G4.BizPermit.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace G4.BizPermit.Dal
{
    public class FeeData
    {
        public static List<Fee> ListAll()
        {
            using (DB context = new DB())
            {
                return context.Fees.Include(x => x.Status).ToList();
            }
        }

        public static bool Add(Fee fee)
        {
            using(DB context = new DB())
            {
                fee.CreatedDate = DateTime.Now;
                fee.CreatedBy = 1;
                context.Fees.Add(fee);
                try
                {
                    context.SaveChanges();
                }catch
                {
                    return false;
                }
                return true;
            }
        }

        public static Fee GetById(string id)
        {
            using(DB context = new DB())
            {
                Fee fee = context.Fees.Where(f => f.UniqueId == new Guid(id)).SingleOrDefault();
                return fee;
            }
        }

        public static bool Edit(Fee fee)
        {
            using(DB context = new DB())
            {
                Fee _fee = context.Fees.Where(f => f.UniqueId == fee.UniqueId).SingleOrDefault();
                _fee.Name = fee.Name;
                _fee.Rate = fee.Rate;
                _fee.isQuarterly = fee.isQuarterly;
                _fee.StatusId = fee.StatusId;
                _fee.withInterest = fee.withInterest;
                _fee.isActive = fee.isActive;
                try
                {
                    context.SaveChanges();
                }catch{
                    return false;
                }
                return true;
            }
        }

        public static bool Delete(String id)
        {
            using(DB context = new DB())
            {
                Fee _fee = context.Fees.Where(f => f.UniqueId == new Guid(id)).SingleOrDefault();
                context.Fees.Remove(_fee);
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
    }
}
