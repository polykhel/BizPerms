using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BizPerms.Models
{
    public class AssessmentViewModel
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public DateTime lastDatePaid { get; set; }
        public string lastQuarterPaid { get; set; }
        public bool isNew { get; set; }
        public bool completeRequirements { get; set;}
        public int? isCollected { get; set; }
        public bool isFirst { get; set; }
        public bool isSecond { get; set; }
        public bool isThird { get; set; }
        public bool isFourth { get; set; }
        public string quarter { get; set; }
    }
}