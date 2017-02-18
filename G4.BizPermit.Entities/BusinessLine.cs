using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G4.BizPermit.Entities
{
    public class BusinessLine
    {
        [Key]
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BusinessNatureId { get; set; }
        [ForeignKey("BusinessNatureId")]
        public virtual BusinessNature BusinessNature { get; set; }
        public bool isActive { get; set; }
    }
}
