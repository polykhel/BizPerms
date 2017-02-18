using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using G4.BizPermit.Entities;

namespace G4.BizPermit.Dal
{
    public class BarangayData
    {
        public static List<Barangay> ListAll()
        {
            using (DB context = new DB())
            {
                return context.Barangays.Include(x => x.District.City.Province).ToList();
            }
        }

        public static bool Add(Barangay obj)
        {
            using (DB context = new DB())
            {
                obj.UniqueId = Guid.NewGuid();
                context.Barangays.Add(obj);
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
                Barangay obj = context.Barangays.Where(o => o.UniqueId == new Guid(UniqueId)).SingleOrDefault();
                context.Barangays.Remove(obj);
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

        public static bool Edit(Barangay obj)
        {
            using (DB context = new DB())
            {
                Barangay _obj = context.Barangays.Where(o => o.UniqueId == obj.UniqueId).SingleOrDefault();
                _obj.DistrictId = obj.DistrictId;
                _obj.Code = obj.Code;
                _obj.Name = obj.Name;
                _obj.Description = obj.Description;
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

        public static Barangay GetById(string uniqueId)
        {
            using (DB context = new DB())
            {
                Barangay obj = context.Barangays.Where(o => o.UniqueId == new Guid(uniqueId)).SingleOrDefault();
                return obj;
            }
        }
    }
}
