using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using G4.BizPermit.Entities;

namespace G4.BizPermit.Dal
{
    public class BusinessRecordData
    {
        public static List<BusinessRecord> ListAll()
        {
            DB context = new DB();
                return context.BusinessRecords.Include(x => x.Barangay)
                    .Include(x => x.BusinessDetail.BusinessLine.BusinessNature)
                    .Include(x => x.BusinessType)
                    .Include(x => x.City)
                    .Include(x => x.District)
                    .Include(x => x.BusinessOwner)
                    .Include(x => x.Province)
                    .Include(x => x.Requirements)
                    .Include(x => x.Street)
                    .ToList();
        }
        public static List<int> GetAllReqId(int id)
        {
            DB context = new DB();
            return context.BusinessRecords.Find(id).Requirements.Select(x => x.Id).ToList();

        }
        public static bool Add(BusinessRecord obj)
        {
            DB context = new DB();
                obj.UniqueId = Guid.NewGuid();
                context.BusinessRecords.Add(obj);
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

        public static bool Delete(String UniqueId)
        {
            using (DB context = new DB())
            {
                BusinessRecord obj = context.BusinessRecords.Include(x => x.Barangay)
                    .Include(x => x.BusinessDetail.BusinessLine.BusinessNature)
                    .Include(x => x.BusinessType)
                    .Include(x => x.City)
                    .Include(x => x.District)
                    .Include(x => x.BusinessOwner)
                    .Include(x => x.Province)
                    .Include(x => x.Requirements)
                    .Include(x => x.Street).Where(o => o.UniqueId == new Guid(UniqueId)).SingleOrDefault();
                //get offical receipt
                context.BusinessRecords.Remove(obj);
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

        public static bool Edit(BusinessRecord obj)
        {
            using (DB context = new DB())
            {
                BusinessRecord _obj = context.BusinessRecords.Where(o => o.UniqueId == obj.UniqueId).SingleOrDefault();
                _obj.BusinessName = obj.BusinessName;
                _obj.BusinessDetailId = obj.BusinessDetailId;
                _obj.OwnerId = obj.OwnerId;
                _obj.StartDate = obj.StartDate.Date;
                _obj.ContactNo =  obj.ContactNo;
                _obj.FaxNo = obj.FaxNo;
                _obj.ProvinceId = obj.ProvinceId;
                _obj.CityId = obj.CityId;
                _obj.DistrictId = obj.DistrictId;
                _obj.BarangayId = obj.BarangayId;
                _obj.StreetId = obj.StreetId;
                _obj.StreetNo = obj.StreetNo;
                _obj.BlockNo = obj.BlockNo;
                _obj.Address = obj.Address;
                _obj.BuildingName = obj.BuildingName;
                _obj.FloorNo = obj.FloorNo;
                _obj.isActive = obj.isActive;
                _obj.BusinessTypeId = obj.BusinessTypeId;
                _obj.isRetired = obj.isRetired;
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

        public static BusinessRecord GetById(string uniqueId)
        {
            using (DB context = new DB())
            {
                BusinessRecord obj = context.BusinessRecords.Include(x => x.Barangay)
                    .Include(x => x.BusinessDetail.BusinessLine.BusinessNature)
                    .Include(x => x.BusinessType)
                    .Include(x => x.City)
                    .Include(x => x.District)
                    .Include(x => x.BusinessOwner)
                    .Include(x => x.Province)
                    .Include(x => x.Requirements)
                    .Include(x => x.Street).Where(o => o.UniqueId == new Guid(uniqueId)).SingleOrDefault();
                return obj;
            }
        }
    }
}
