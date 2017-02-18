using G4.BizPermit.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace G4.BizPermit.Dal
{
    public class CitiesData
    {
        public static List<City> ListAll()
        {
            using(DB context = new DB())
            {
                return context.Cities.Include(x => x.Province).ToList();
            }
        }

        public static bool Add(City city)
        {
            using (DB context = new DB())
            {
                var codeExists = context.Cities.Count(p => p.Code == city.Code);
                if (codeExists <= 0)
                {
                    city.UniqueId = Guid.NewGuid();
                    context.Cities.Add(city);
                    context.SaveChanges();
                }
                else
                {
                    return false;
                }
                return true;
            }
        }

        public static City GetById(string uniqueId)
        {
            using(DB context = new DB())
            {
                City city = context.Cities.Where(c => c.UniqueId == new Guid(uniqueId)).SingleOrDefault();
                return city;
            }
        }

        public static bool Edit(City city)
        {
            using (DB context = new DB())
            {
                City _city = context.Cities.Where(p => p.UniqueId == city.UniqueId).SingleOrDefault();
                var codeExists = context.Provinces.Count(p => p.Code == city.Code);
                if (codeExists <= 0)
                {
                    _city.Code = city.Code;
                    _city.Name = city.Name;
                    _city.ProvinceId = city.ProvinceId;
                    _city.Description = city.Description;
                    _city.isActive = city.isActive;
                    context.SaveChanges();
                }
                else
                {
                    return false;
                }
                return true;
            }
        }

        public static bool Delete(string uniqueId)
        {
            using (DB context = new DB())
            {
                City _city = context.Cities.Where(c => c.UniqueId == new Guid(uniqueId)).SingleOrDefault();
                context.Cities.Remove(_city);
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
