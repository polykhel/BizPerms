using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G4.BizPermit.Entities;
using G4.BizPermit.Dal;

namespace G4.BizPermit.Dal
{
    public class BusinessTypeData
    {
        public static List<BusinessType> ListAll()
        {
            using (DB context = new DB())
            {
                return context.BusinessTypes.ToList();
            }
        }

        public static bool Add(BusinessType obj)
        {
            using (DB context = new DB())
            {
                obj.UniqueId = Guid.NewGuid();
                context.BusinessTypes.Add(obj);
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

        public static bool Edit(BusinessType obj)
        {
            using (DB context = new DB())
            {
                BusinessType _obj = context.BusinessTypes.Where(o => o.UniqueId == obj.UniqueId).SingleOrDefault();
                _obj.Code = obj.Code;
                _obj.Description = obj.Description;
                _obj.isActive = obj.isActive;
                _obj.Name = obj.Name;
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
                BusinessType obj = context.BusinessTypes.Where(o => o.UniqueId == new Guid(id)).SingleOrDefault();
                context.BusinessTypes.Remove(obj);
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

        public static BusinessType GetById(string id)
        {
            using (DB context = new DB())
            {
                BusinessType obj = context.BusinessTypes.Where(o => o.UniqueId == new Guid(id)).SingleOrDefault();
                return obj;
            }
        }
    }
}
