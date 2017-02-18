using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G4.BizPermit.Entities;

namespace G4.BizPermit.Dal
{
    public class StatusData
    {
        public static List<Status> ListAll()
        {
            using (DB context = new DB())
            {
                return context.Statuses.ToList();
            }
        }

        public static bool Add(Status obj)
        {
            using (DB context = new DB())
            {
                obj.UniqueId = Guid.NewGuid();
                context.Statuses.Add(obj);
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
                Status obj = context.Statuses.Where(o => o.UniqueId == new Guid(UniqueId)).SingleOrDefault();
                context.Statuses.Remove(obj);
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

        public static bool Edit(Status obj)
        {
            using (DB context = new DB())
            {
                Status _obj = context.Statuses.Where(o => o.UniqueId == obj.UniqueId).SingleOrDefault();
                _obj.Name = obj.Name;
                _obj.CreatedDate = obj.CreatedDate;
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

        public static Status GetById(Guid uniqueId)
        {
            using (DB context = new DB())
            {
                Status obj = context.Statuses.Where(o => o.UniqueId == uniqueId).SingleOrDefault();
                return obj;
            }
        }
    }
}