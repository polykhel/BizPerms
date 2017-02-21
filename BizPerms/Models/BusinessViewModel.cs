using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BizPerms.Models
{
    public class BusinessViewModel
    {
        public List<SelectListItem> BusinessNames { get; set; }
        //public List<string> Owner { get; set; }
        //public List<string> Address { get; set; }
    }
}