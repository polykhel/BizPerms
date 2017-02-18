using G4.BizPermit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace G4.BizPermit.Dal
{
    public class ProvincesData
    {
        public static List<Province> ListAll()
        {
            using(DB context = new DB())
            {
                return context.Provinces.ToList();
            }
        }

        public static bool Add(Province obj)
        {
            using(DB context = new DB())
            {
                var codeExists = context.Provinces.Count(p => p.Code == obj.Code);
                if(codeExists <= 0)
                {
                    obj.UniqueId = Guid.NewGuid();
                    context.Provinces.Add(obj);
                    context.SaveChanges();
                }else
                {
                    return false;
                }
                return true;
            }
        }

        public static Province GetById(string uniqueId)
        {
            using (DB context = new DB())
            {
                Province prov = context.Provinces.Where(p => p.UniqueId == new Guid(uniqueId)).SingleOrDefault();
                return prov;
            }
        }

        public static bool Edit(Province prov)
        {
            using(DB context = new DB())
            {
                Province _prov = context.Provinces.Where(p => p.UniqueId == prov.UniqueId).SingleOrDefault();
                var codeExists = context.Provinces.Count(p => p.Code == prov.Code);
                if (codeExists <= 0)
                {
                    _prov.Code = prov.Code;
                    _prov.Name = prov.Name;
                    _prov.Description = prov.Description;
                    _prov.isActive = prov.isActive;
                    context.SaveChanges();
                }else
                {
                    return false;
                }
                return true;
            }
        }

        public static bool Delete(string uniqueId)
        {
            using(DB context = new DB())
            {
                Province _prov = context.Provinces.Where(p => p.UniqueId == new Guid(uniqueId)).SingleOrDefault();
                context.Provinces.Remove(_prov);
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
    }
}
