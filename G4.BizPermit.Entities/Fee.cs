using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G4.BizPermit.Entities
{
    public class Fee
    {
        [Key]
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public bool isQuarterly { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
        public bool withInterest { get; set; }
        public bool isActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
