using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G4.BizPermit.Entities
{
    public class BusinessDetail
    {
        [Key]
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public int BusinessLineId { get; set; }
        [ForeignKey("BusinessLineId")]
        public virtual BusinessLine BusinessLine { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Capital { get; set; }
        public decimal Gross { get; set; }
        public bool isNew { get; set; }
        public DateTime lastPayDate { get; set; }
    }
}
