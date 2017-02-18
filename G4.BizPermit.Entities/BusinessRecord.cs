using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G4.BizPermit.Entities
{
    public class BusinessRecord
    {
        public BusinessRecord()
        {
            this.Requirements = new List<Requirement>();
        }

        [Key]
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual BusinessOwner BusinessOwner { get; set; }
        public string BusinessName { get; set; }
        public int BusinessDetailId { get; set; }
        [ForeignKey("BusinessDetailId")]
        public virtual BusinessDetail BusinessDetail { get; set; }
        public DateTime StartDate { get; set; }
        public string ContactNo { get; set; }
        public string FaxNo { get; set; }
        public int? ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }
        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        public int? DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }
        public int? BarangayId { get; set; }
        [ForeignKey("BarangayId")]
        public virtual Barangay Barangay { get; set; }
        public int? StreetId { get; set; }
        [ForeignKey("StreetId")]
        public virtual Street Street { get; set; }
        public int StreetNo { get; set; }
        public int BlockNo { get; set;}
        public string Address { get; set; }
        public string BuildingName { get; set; }
        public int FloorNo { get; set; }
        public bool isActive { get; set; }
        public int BusinessTypeId { get; set; }
        [ForeignKey("BusinessTypeId")]
        public virtual BusinessType BusinessType { get; set; }
        public bool isRetired { get; set; }
        public bool isAssessed { get; set; }
        public bool isPayed { get; set; }
        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
