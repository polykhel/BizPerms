using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using G4.BizPermit.Entities;

namespace G4.BizPermit.Dal
{
    public class StreetData
    {
        public static List<Street> ListAll()
        {
            using (DB context = new DB())
            {
                return context.Streets.Include(x => x.Barangay.District.City.Province).ToList();
            }
        }

        public static bool Add(Street obj)
        {
            using (DB context = new DB())
            {
                obj.UniqueId = Guid.NewGuid();
                context.Streets.Add(obj);
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

        public static bool Delete(String UniqueId)
        {
            using (DB context = new DB())
            {
                Street obj = context.Streets.Where(o => o.UniqueId == new Guid(UniqueId)).SingleOrDefault();
                context.Streets.Remove(obj);
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

        public static bool Edit(Street obj)
        {
            using (DB context = new DB())
            {
                Street _obj = context.Streets.Where(o => o.UniqueId == obj.UniqueId).SingleOrDefault();
                _obj.Name = obj.Name;
                _obj.Description = obj.Description;
                _obj.Code = obj.Code;
                _obj.BarangayId = obj.BarangayId;
                _obj.isActive = obj.isActive;
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

        public static Street GetById(string uniqueId)
        {
            using (DB context = new DB())
            {
                Street obj = context.Streets.Where(o => o.UniqueId == new Guid(uniqueId)).SingleOrDefault();
                return obj;
            }
        }
    }
}
