using G4.BizPermit.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4.BizPermit.Dal
{
    public class DB : DbContext
    {
        public DB()
                : base("DefaultConnection")
        {
        }

        public DbSet<Barangay> Barangays { get; set; }
        public DbSet<BusinessDetail> BusinessDetails { get; set; }
        public DbSet<BusinessLine> BusinessLines { get; set; }
        public DbSet<BusinessNature> BusinessNatures { get; set; }
        public DbSet<BusinessOwner> BusinessOwners { get; set; }
        public DbSet<BusinessRecord> BusinessRecords { get; set; }
        public DbSet<BusinessType> BusinessTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Quarter> Quarters { get; set; }
        public DbSet<Cutoff> Cutoffs { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Fee> Fees { get; set; }
		public DbSet<Bank> BankRecords {get; set; }
    }
}
