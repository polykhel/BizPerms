using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G4.BizPermit.Entities;
using G4.BizPermit.Dal;

namespace G4.BizPermit.Dal
{
    public class BusinessOwnerData
    {
        public static List<BusinessOwner> ListAll()
        {
            using (DB context = new DB())
            {
                return context.BusinessOwners.ToList();
            }
        }

        public static bool Add(BusinessOwner obj)
        {
            using (DB context = new DB())
            {
                obj.UniqueId = Guid.NewGuid();
                context.BusinessOwners.Add(obj);
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

        public static bool Edit(BusinessOwner obj)
        {
            using (DB context = new DB())
            {
                BusinessOwner _obj = context.BusinessOwners.Where(o => o.UniqueId == obj.UniqueId).SingleOrDefault();
                _obj.Address = obj.Address;
                _obj.BirthDate = obj.BirthDate;
                _obj.ContactNo = obj.ContactNo;
                _obj.CorporateName = obj.CorporateName;
                _obj.Designation = obj.Designation;
                _obj.FirstName = obj.FirstName;
                _obj.Gender = obj.Gender;
                _obj.isActive = obj.isActive;
                _obj.LastName = obj.LastName;
                _obj.MaritalStatus = obj.MaritalStatus;
                _obj.MiddleName = obj.MiddleName;
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
                BusinessOwner obj = context.BusinessOwners.Where(o => o.UniqueId == new Guid(id)).SingleOrDefault();
                context.BusinessOwners.Remove(obj);
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

        public static BusinessOwner GetById(string id)
        {
            using (DB context = new DB())
            {
                BusinessOwner obj = context.BusinessOwners.Where(o => o.UniqueId == new Guid(id)).SingleOrDefault();
                return obj;
            }
        }
    }
}
