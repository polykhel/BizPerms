using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using G4.BizPermit.Entities;

namespace G4.BizPermit.Dal
{
    public class RequirementData
    {
        public static List<Requirement> ListAll()
        {
            DB context = new DB();
                return context.Requirements.Include(x => x.Status).ToList();
        }

        public static List<Requirement> GetNew()
        {
            DB context = new DB();
                return context.Requirements.Include(x => x.Status).Where(x => x.StatusId != 2).ToList();
        }
        public static List<Requirement> GetRenew()
        {
            DB context = new DB();
                return context.Requirements.Include(x => x.Status).Where(x => x.StatusId != 1).ToList();
        }

        public static bool Add(Requirement obj)
        {
            using (DB context = new DB())
            {
                obj.UniqueId = Guid.NewGuid();
                context.Requirements.Add(obj);
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
                Requirement obj = context.Requirements.Where(o => o.UniqueId == new Guid(UniqueId)).SingleOrDefault();
                context.Requirements.Remove(obj);
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

        public static bool Edit(Requirement obj)
        {
            using (DB context = new DB())
            {
                Requirement _obj = context.Requirements.Where(o => o.UniqueId == obj.UniqueId).SingleOrDefault();
                _obj.Name = obj.Name;
                _obj.StatusId = obj.StatusId;
                _obj.IsActive = obj.IsActive;
                _obj.CreatedBy = obj.CreatedBy;
                _obj.Status = obj.Status;
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

        public static Requirement GetById(Guid uniqueId)
        {
            using (DB context = new DB())
            {
                Requirement obj = context.Requirements.Where(o => (o.UniqueId == uniqueId)).SingleOrDefault();
                return obj;
            }
        }
    }
}