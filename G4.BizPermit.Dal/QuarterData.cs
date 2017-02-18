using G4.BizPermit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.BizPermit.Dal
{
    public class QuarterData
    {
        public static List<Quarter> ListAll()
        {
            using (DB context = new DB())
            {
                return context.Quarters.ToList();
            }
        }

        public static bool Add(Quarter obj)
        {
            using (DB context = new DB())
            {
                obj.CreatedDate = DateTime.Now;
                context.Quarters.Add(obj);
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

        public static bool Delete(int id)
        {
            using (DB context = new DB())
            {
                Quarter obj = context.Quarters.Where(o => o.Id == id).SingleOrDefault();
                context.Quarters.Remove(obj);
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

        public static bool Edit(Quarter obj)
        {
            using (DB context = new DB())
            {
                Quarter _obj = context.Quarters.Where(o => o.Id == obj.Id).SingleOrDefault();
                _obj.Name = obj.Name;
                _obj.IsActive = obj.IsActive;
                _obj.CreatedBy = obj.CreatedBy;
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

        public static Quarter GetById(int id)
        {
            using (DB context = new DB())
            {
                Quarter obj = context.Quarters.Where(o => o.Id == id).SingleOrDefault();
                return obj;
            }
        }
    }
}
