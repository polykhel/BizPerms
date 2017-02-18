using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using G4.BizPermit.Entities;

namespace G4.BizPermit.Dal
{
    public class BusinessLineData
    {
        public static List<BusinessLine> ListAll()
        {
            using (DB context = new DB())
            {
                return context.BusinessLines.Include(x => x.BusinessNature).ToList();
            }
        }

        //ADD
        public static bool Add(BusinessLine obj)
        {
            using (DB context = new DB())
            {
                obj.UniqueId = Guid.NewGuid();
                context.BusinessLines.Add(obj);

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
        public static bool Edit(BusinessLine obj)
        {
            using (DB context = new DB())
            {
                BusinessLine _obj = context.BusinessLines.Where(o => o.UniqueId == obj.UniqueId).SingleOrDefault();

                _obj.BusinessNature = obj.BusinessNature;
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

        //DELETE
        public static bool Delete(string id)
        {
            using (DB context = new DB())
            {
                BusinessLine obj = context.BusinessLines.Where(o => o.UniqueId == new Guid(id)).SingleOrDefault();

                context.BusinessLines.Remove(obj);

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

        public static BusinessLine GetById(string id)
        {
            using (DB context = new DB())
            {
                BusinessLine obj = context.BusinessLines.Include(x => x.BusinessNature).Where(o => o.UniqueId == new Guid(id)).SingleOrDefault();
                return obj;
            }
        }
    }
}
