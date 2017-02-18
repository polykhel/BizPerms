using System;
using System.Collections.Generic;
using System.Linq;
using G4.BizPermit.Entities;

namespace G4.BizPermit.Dal
{
    public class BusinessNatureData
    {
        public static List<BusinessNature> ListAll()
        {
            using (DB context = new DB())
            {
                return context.BusinessNatures.ToList();
            }
        }

        //ADD
        public static bool Add(BusinessNature obj)
        {
            using (DB context = new DB())
            {
                obj.UniqueId = Guid.NewGuid();
                context.BusinessNatures.Add(obj);

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

        //EDIT
        public static bool Edit(BusinessNature obj)
        {
            using (DB context = new DB())
            {
                BusinessNature _obj = context.BusinessNatures.Where(o => o.UniqueId == obj.UniqueId).SingleOrDefault();

                _obj.Code = obj.Code;
                _obj.BusinessNatureName = obj.BusinessNatureName;
                _obj.Description = obj.Description;
                _obj.IsActive = obj.IsActive;

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

        //DELETE
        public static bool Delete(string id)
        {
            using (DB context = new DB())
            {
                BusinessNature obj = context.BusinessNatures.Where(o => o.UniqueId == new Guid(id)).SingleOrDefault();

                context.BusinessNatures.Remove(obj);

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

        public static BusinessNature GetById(string id)
        {
            using (DB context = new DB())
            {
                BusinessNature obj = context.BusinessNatures.Where(o => o.UniqueId == new Guid(id)).SingleOrDefault();
                return obj;
            }
        }
    }
}
