using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G4.BizPermit.Entities;
using G4.BizPermit.Dal;

namespace G4.BizPermit.Dal
{
    public class CutoffData
    {
        public static List<Cutoff> ListAll()
        {
            using (DB context = new DB())
            {
                return context.Cutoffs.ToList();
            }
        }

        public static bool Add(Cutoff obj)
        {
            using (DB context = new DB())
            {
                obj.UniqueId = Guid.NewGuid();
                context.Cutoffs.Add(obj);
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
                Cutoff obj = context.Cutoffs.Where(o => o.UniqueId == new Guid(UniqueId)).SingleOrDefault();
                context.Cutoffs.Remove(obj);
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

        public static bool Edit(Cutoff obj)
        {
            using (DB context = new DB())
            {
                Cutoff _obj = context.Cutoffs.Where(o => o.UniqueId == obj.UniqueId).SingleOrDefault();
                _obj.Name = obj.Name;
                _obj.IsActive = obj.IsActive;
                _obj.CreatedBy = obj.CreatedBy;
                _obj.CuttoffDate = obj.CuttoffDate;
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

        public static Cutoff GetById(string uniqueId)
        {
            using (DB context = new DB())
            {
                Cutoff obj = context.Cutoffs.Where(o => o.UniqueId == new Guid(uniqueId)).SingleOrDefault();
                return obj;
            }
        }
    }
}
