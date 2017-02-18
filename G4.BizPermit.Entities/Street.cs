using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4.BizPermit.Entities
{
    public class Street
    {
        [Key]
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BarangayId { get; set; }
        [ForeignKey("BarangayId")]
        public virtual Barangay Barangay { get; set; }
        public bool isActive { get; set; }
    }
}
