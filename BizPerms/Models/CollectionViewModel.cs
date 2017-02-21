using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BizPerms.Models
{
    public class CollectionViewModel
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string OwnerName { get; set; }
        public bool isNew { get; set; }
        public int orNumber { get; set; }
        public DateTime orDate { get; set; }
        public int? quarter { get; set; }
        public int lastQuarterPaid { get; set; }
        public DateTime lastDatePaid { get; set; }
        public decimal payableAmount { get; set; }
        public decimal tenderedAmount { get; set; }
        public decimal changeAmount { get; set; }
    }
}