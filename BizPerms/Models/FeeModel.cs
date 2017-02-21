using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BizPerms.Models
{
    public class FeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
    }
}