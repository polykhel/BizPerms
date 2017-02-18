﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4.BizPermit.Entities
{
    public class Quarter
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool firstQtr { get; set; }
        public bool secondQtr { get; set; }
        public bool thirdQtr { get; set; }
        public bool fourthQtr { get; set; }
    }
}
