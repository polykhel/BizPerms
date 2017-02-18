using System;
using System.ComponentModel.DataAnnotations;

namespace G4.BizPermit.Entities
{
    public class BusinessNature
    {
        [Key]
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public int Code { get; set; }
        public string BusinessNatureName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
