using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using G4.BizPermit.Entities;

namespace G4.BizPermit.Dal
{
    public class DistrictData
    {
        public static List<District> ListAll()
        {
            using (DB context = new DB())
            {
                return context.Districts.Include(x => x.City.Province).ToList();
            }
        }

        public static bool Add(District obj)
        {
            using (DB context = new DB())
            {
                obj.UniqueId = Guid.NewGuid();
                context.Districts.Add(obj);
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

        public static bool Edit(District obj)
        {
            using (DB context = new DB())
            {
                District _obj = context.Districts.Where(o => o.UniqueId == obj.UniqueId).SingleOrDefault();
                _obj.Name = obj.Name;
                _obj.Description = obj.Description;
                _obj.CityId = obj.CityId;
                _obj.Code = obj.Code;
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

        public static bool Delete(string id)
        {
            using (DB context = new DB())
            {
                District obj = context.Districts.Where(o => o.UniqueId == new Guid(id)).SingleOrDefault();
                context.Districts.Remove(obj);
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

        public static District GetById(string id)
        {
            using (DB context = new DB())
            {
                District obj = context.Districts.Where(o => o.UniqueId == new Guid(id)).SingleOrDefault();
                return obj;
            }
        }
    }
}
