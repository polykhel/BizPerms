using G4.BizPermit.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4.BizPermit.Dal
{
    public class BankData
    {
        public static List<Bank> ListAll()
        {
            using (DB context = new DB())
            {
                return context.BankRecords.ToList();
            }
        }
        public static bool Add(Bank obj)
        {
            using (DB context = new DB())
            {
                obj.UniqueId = Guid.NewGuid();
                context.BankRecords.Add(obj);
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

        public static bool Edit(Bank obj)
        {
            using (DB context = new DB())
            {
                Bank _obj = context.BankRecords.Where(o => o.UniqueId == obj.UniqueId).SingleOrDefault();
                _obj.Name = obj.Name;
                _obj.IsActive = obj.IsActive;
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

        public static bool Delete(String uniq)
        {
            using (DB context = new DB())
            {
                Bank obj = context.BankRecords.Where(o => o.UniqueId == new Guid(uniq)).SingleOrDefault();
                context.BankRecords.Remove(obj);
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


        public static Bank GetById(string uid)
        {
            using (DB context = new DB())
            {
                Bank obj = context.BankRecords.Where(o => o.UniqueId == new Guid(uid)).SingleOrDefault();
                return obj;
            }
        }
    }
}