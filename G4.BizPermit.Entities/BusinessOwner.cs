using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4.BizPermit.Entities
{
    public class BusinessOwner
    {
        [Key]
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Designation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime BirthDate { get; set; }
        public string CorporateName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public bool isActive { get; set; }
    }
}
