using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4.BizPermit.Entities
{
    public class OfficialReceipt
    {
        [Key]
        public int Id { get; set; }
        public int ORNumber { get; set; }
        public DateTime ORDate { get; set; }
        public List<Fee> FeesPaid { get; set; }
        public decimal totalAmount { get; set; }
        public decimal tenderedAmount { get; set; }
        public decimal changeAmount { get; set; }
        public int BusinessRecordId { get; set; }
        [ForeignKey("BusinessRecordId")]
        public virtual BusinessRecord BusinessRecord { get; set; }
    }
}
