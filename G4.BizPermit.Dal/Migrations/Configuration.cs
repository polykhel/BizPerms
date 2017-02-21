namespace G4.BizPermit.Dal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using G4.BizPermit.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<G4.BizPermit.Dal.DB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(G4.BizPermit.Dal.DB context)
        {
            //BUSINESS NATURE -- START
            BusinessNature bn1 = new BusinessNature();
            bn1.BusinessNatureName = "Food Services";
            bn1.Code = 1;
            bn1.Description = "Restaurants, etc.";
            bn1.UniqueId = Guid.NewGuid();
            bn1.IsActive = true;

            BusinessNature bn2 = new BusinessNature();
            bn2.BusinessNatureName = "Retail";
            bn2.Code = 2;
            bn2.Description = "Supermarket, stores, etc.";
            bn2.UniqueId = Guid.NewGuid();
            bn2.IsActive = true;

            BusinessNature bn3 = new BusinessNature();
            bn3.BusinessNatureName = "Wholesale";
            bn3.Code = 3;
            bn3.Description = "sales many";
            bn3.UniqueId = Guid.NewGuid();
            bn3.IsActive = true;

            BusinessNature bn4 = new BusinessNature();
            bn4.BusinessNatureName = "Manufacturing";
            bn4.Code = 4;
            bn4.Description = "manufactures goods";
            bn4.UniqueId = Guid.NewGuid();
            bn4.IsActive = true;

            BusinessNature bn5 = new BusinessNature();
            bn5.BusinessNatureName = "Services";
            bn5.Code = 5;
            bn5.Description = "provides service";
            bn5.UniqueId = Guid.NewGuid();
            bn5.IsActive = true;
            //BUSINESS NATURE -- END

            //BUSINESS LINE -- START
            BusinessLine bl1 = new BusinessLine();
            bl1.Name = "Spa";
            bl1.BusinessNature = bn5;
            bl1.Code = 1;
            bl1.Description = "parlor and massage";
            bl1.UniqueId = Guid.NewGuid();
            bl1.isActive = true;

            BusinessLine bl2 = new BusinessLine();
            bl2.Name = "Barber";
            bl2.BusinessNature = bn5;
            bl2.Code = 2;
            bl2.Description = "kwentong barbero";
            bl2.UniqueId = Guid.NewGuid();
            bl2.isActive = true;

            BusinessLine bl3 = new BusinessLine();
            bl3.Name = "Supermarket";
            bl3.BusinessNature = bn2;
            bl3.Code = 3;
            bl3.Description = "nagbebenta";
            bl3.UniqueId = Guid.NewGuid();
            bl3.isActive = true;

            BusinessLine bl4 = new BusinessLine();
            bl4.Name = "Department Store";
            bl4.BusinessNature = bn2;
            bl4.Code = 4;
            bl4.Description = "tingi tingi lang";
            bl4.UniqueId = Guid.NewGuid();
            bl4.isActive = true;

            BusinessLine bl5 = new BusinessLine();
            bl5.Name = "Restaurant";
            bl5.BusinessNature = bn1;
            bl5.Code = 5;
            bl5.Description = "kainan";
            bl5.UniqueId = Guid.NewGuid();
            bl5.isActive = true;
            //BUSINESS LINE -- END

            //BUSINESS DETAIL -- START
            BusinessDetail bd1 = new BusinessDetail();
            bd1.BirthDate = DateTime.Now;
            bd1.Name = "biz1";
            bd1.BusinessLine = bl1;
            bd1.Capital = (decimal)100.12;
            bd1.Gross = (decimal)234.23;
            bd1.isNew = true;
            bd1.lastPayDate = DateTime.ParseExact("2016-12-31", "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            bd1.UniqueId = Guid.NewGuid();

            BusinessDetail bd2 = new BusinessDetail();
            bd2.BirthDate = DateTime.Now;
            bd2.Name = "biz2";
            bd2.BusinessLine = bl2;
            bd2.Capital = (decimal)200.12;
            bd2.Gross = (decimal)2134.23;
            bd2.isNew = true;
            bd2.lastPayDate = DateTime.ParseExact("2016-12-31", "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            bd2.UniqueId = Guid.NewGuid();
            //BUSINESS DETAIL -- END

            //BUSINESS OWNER -- START
            BusinessOwner bo1 = new BusinessOwner();
            bo1.FirstName = "Michael";
            bo1.MiddleName = "T.";
            bo1.LastName = "Pollente";
            bo1.MaritalStatus = "Single";
            bo1.UniqueId = Guid.NewGuid();
            bo1.Gender = "Male";
            bo1.CorporateName = "Jollibee";
            bo1.BirthDate = DateTime.ParseExact("1996-06-13", "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            bo1.ContactNo = "1234";
            bo1.Designation = "Mr.";
            bo1.isActive = true;

            BusinessOwner bo2 = new BusinessOwner();
            bo2.FirstName = "Jon";
            bo2.MiddleName = "Lang";
            bo2.LastName = "Jovi";
            bo2.MaritalStatus = "Single";
            bo2.UniqueId = Guid.NewGuid();
            bo2.Gender = "Female";
            bo2.CorporateName = "Mayaman Corp";
            bo2.BirthDate = DateTime.ParseExact("2016-12-31", "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            bo2.ContactNo = "1234";
            bo2.Designation = "Ms.";
            bo2.isActive = true;
            //BUSINESS OWNER -- END

            //BUSINESS TYPE -- START
            BusinessType bt1 = new BusinessType();
            bt1.Name = "Sole Proprietorship";
            bt1.Code = 1;
            bt1.Description = "mag-isa ka lang";
            bt1.isActive = true;
            bt1.UniqueId = Guid.NewGuid();

            BusinessType bt2 = new BusinessType();
            bt2.Name = "Partnership";
            bt2.Code = 2;
            bt2.Description = "dalawa na kayo";
            bt2.isActive = true;
            bt2.UniqueId = Guid.NewGuid();

            BusinessType bt3 = new BusinessType();
            bt3.Name = "Corporation";
            bt3.Code = 3;
            bt3.Description = "woah dami";
            bt3.isActive = true;
            bt3.UniqueId = Guid.NewGuid();
            //BUSINESS TYPE -- END

            //BANK -- START
            Bank bank1 = new Bank();
            bank1.Name = "BPI";
            bank1.CreatedBy = 1;
            bank1.CreatedDate = DateTime.Now;
            bank1.IsActive = true;
            bank1.UniqueId = Guid.NewGuid();

            Bank bank2 = new Bank();
            bank2.Name = "BDO";
            bank2.CreatedBy = 1;
            bank2.CreatedDate = DateTime.Now;
            bank2.IsActive = true;
            bank2.UniqueId = Guid.NewGuid();
            //BANK -- END

            //PROVINCE -- ADD
            Province prov1 = new Province();
            prov1.UniqueId = Guid.NewGuid();
            prov1.Name = "NCR";
            prov1.Code = 133900000;
            prov1.Description = "Capital";
            prov1.isActive = true;

            Province prov2 = new Province();
            prov2.UniqueId = Guid.NewGuid();
            prov2.Name = "Rizal";
            prov2.Code = 045800000;
            prov2.Description = "probinsya";
            prov2.isActive = true;
            //PROVINCE -- END

            //CITY -- START
            City city1 = new City();
            city1.UniqueId = Guid.NewGuid();
            city1.Name = "Antipolo City";
            city1.Code = 045802000;
            city1.Description = "first class";
            city1.isActive = true;
            city1.Province = prov2;

            City city2 = new City();
            city2.UniqueId = Guid.NewGuid();
            city2.Name = "Cainta";
            city2.Code = 045805000;
            city2.Description = "municipality";
            city2.isActive = true;
            city2.Province = prov2;

            City city3 = new City();
            city3.UniqueId = Guid.NewGuid();
            city3.Name = "Manila";
            city3.Code = 133900000;
            city3.Description = "capital";
            city3.isActive = true;
            city3.Province = prov1;

            City city4 = new City();
            city4.UniqueId = Guid.NewGuid();
            city4.Name = "Quezon City";
            city4.Code = 137404000;
            city4.Description = "big";
            city4.isActive = true;
            city4.Province = prov1;
            //CITY -- END

            //DISTRICT -- START
            District dist1 = new District();
            dist1.City = city1;
            dist1.Code = 1001;
            dist1.Description = "1DAntipolo";
            dist1.Name = "1st District, Antipolo";
            dist1.UniqueId = Guid.NewGuid();
            dist1.isActive = true;

            District dist2 = new District();
            dist2.City = city1;
            dist2.Code = 1002;
            dist2.Description = "2DAntipolo";
            dist2.Name = "2nd District, Antipolo";
            dist2.UniqueId = Guid.NewGuid();
            dist2.isActive = true;

            District dist3 = new District();
            dist3.City = city3;
            dist3.Code = 2001;
            dist3.Description = "1DManila";
            dist3.Name = "1st District, Manila";
            dist3.UniqueId = Guid.NewGuid();
            dist3.isActive = true;

            District dist4 = new District();
            dist4.City = city3;
            dist4.Code = 2002;
            dist4.Description = "2DManila";
            dist4.Name = "2nd District, Manila";
            dist4.UniqueId = Guid.NewGuid();
            dist4.isActive = true;
            //DISTRICT -- END

            //BARANGAY -- START
            Barangay bar1 = new Barangay();
            bar1.Name = "San Jose";
            bar1.District = dist1;
            bar1.Code = 1001;
            bar1.Description = "bar1";
            bar1.isActive = true;
            bar1.UniqueId = Guid.NewGuid();

            Barangay bar2 = new Barangay();
            bar2.Name = "Bagong Nayon";
            bar2.District = dist2;
            bar2.Code = 1002;
            bar2.Description = "bar2";
            bar2.isActive = true;
            bar2.UniqueId = Guid.NewGuid();

            Barangay bar3 = new Barangay();
            bar3.Name = "Quiapo";
            bar3.District = dist4;
            bar3.Code = 2001;
            bar3.Description = "bar3";
            bar3.isActive = true;
            bar3.UniqueId = Guid.NewGuid();

            Barangay bar4 = new Barangay();
            bar4.Name = "Sampaloc";
            bar4.District = dist3;
            bar4.Code = 1001;
            bar4.Description = "bar4";
            bar4.isActive = true;
            bar4.UniqueId = Guid.NewGuid();
            //BARANGAY -- END

            //STREET -- START
            Street st1 = new Street();
            st1.Name = "St1";
            st1.Description = "street";
            st1.Barangay = bar1;
            st1.Code = 1001;
            st1.isActive = true;
            st1.UniqueId = Guid.NewGuid();

            Street st2 = new Street();
            st2.Name = "St2";
            st2.Description = "street";
            st2.Barangay = bar2;
            st2.Code = 2001;
            st2.isActive = true;
            st2.UniqueId = Guid.NewGuid();
            //STREET -- END

            //QUARTER -- START
            Quarter qrt1 = new Quarter();
            qrt1.Name = "1st Quarter";
            qrt1.IsActive = true;
            qrt1.CreatedBy = 1;
            qrt1.CreatedDate = DateTime.Now;
            qrt1.firstQtr = true;
            qrt1.secondQtr = false;
            qrt1.thirdQtr = false;
            qrt1.fourthQtr = false;

            Quarter qrt2 = new Quarter();
            qrt2.Name = "2nd Quarter";
            qrt2.IsActive = true;
            qrt2.CreatedBy = 1;
            qrt2.CreatedDate = DateTime.Now;
            qrt2.firstQtr = false;
            qrt2.secondQtr = true;
            qrt2.thirdQtr = false;
            qrt2.fourthQtr = false;

            Quarter qrt3 = new Quarter();
            qrt3.Name = "3rd Quarter";
            qrt3.IsActive = true;
            qrt3.CreatedBy = 1;
            qrt3.CreatedDate = DateTime.Now;
            qrt3.firstQtr = false;
            qrt3.secondQtr = false;
            qrt3.thirdQtr = true;
            qrt3.fourthQtr = false;

            Quarter qrt4 = new Quarter();
            qrt4.Name = "4th Quarter";
            qrt4.IsActive = true;
            qrt4.CreatedBy = 1;
            qrt4.CreatedDate = DateTime.Now;
            qrt4.firstQtr = false;
            qrt4.secondQtr = false;
            qrt4.thirdQtr = false;
            qrt4.fourthQtr = true;
            //QUARTER -- END

            //CUTOFF -- START
            Cutoff cut1 = new Cutoff();
            cut1.Name = "1st";
            cut1.UniqueId = Guid.NewGuid();
            cut1.IsActive = true;
            cut1.CreatedDate = DateTime.Now;
            cut1.CreatedBy = 1;
            cut1.CuttoffDate = DateTime.ParseExact("2017-03-31", "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);

            Cutoff cut2 = new Cutoff();
            cut2.Name = "2nd";
            cut2.UniqueId = Guid.NewGuid();
            cut2.IsActive = true;
            cut2.CreatedDate = DateTime.Now;
            cut2.CreatedBy = 1;
            cut2.CuttoffDate = DateTime.ParseExact("2017-06-30", "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);

            Cutoff cut3 = new Cutoff();
            cut3.Name = "3rd";
            cut3.UniqueId = Guid.NewGuid();
            cut3.IsActive = true;
            cut3.CreatedDate = DateTime.Now;
            cut3.CreatedBy = 1;
            cut3.CuttoffDate = DateTime.ParseExact("2017-09-30", "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);

            Cutoff cut4 = new Cutoff();
            cut4.Name = "4th";
            cut4.UniqueId = Guid.NewGuid();
            cut4.IsActive = true;
            cut4.CreatedDate = DateTime.Now;
            cut4.CreatedBy = 1;
            cut4.CuttoffDate = DateTime.ParseExact("2017-12-31", "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            //CUTOFF -- END

            //STATUS -- START
            Status stat1 = new Status();
            stat1.Name = "New";
            stat1.UniqueId = Guid.NewGuid();
            stat1.CreatedDate = DateTime.Now;
            stat1.CreatedBy = 1;

            Status stat2 = new Status();
            stat2.Name = "Renew";
            stat2.UniqueId = Guid.NewGuid();
            stat2.CreatedDate = DateTime.Now;
            stat2.CreatedBy = 1;

            Status stat3 = new Status();
            stat3.Name = "Both";
            stat3.UniqueId = Guid.NewGuid();
            stat3.CreatedDate = DateTime.Now;
            stat3.CreatedBy = 1;
            //STATUS -- END

            //FEES -- START
            Fee fee1 = new Fee();
            fee1.Name = "Business Tax New";
            fee1.Rate = 1500;
            fee1.isQuarterly = true;
            fee1.isActive = true;
            fee1.withInterest = false;
            fee1.UniqueId = Guid.NewGuid();
            fee1.CreatedBy = 1;
            fee1.CreatedDate = DateTime.Now;
            fee1.Status = stat1;

            Fee fee2 = new Fee();
            fee2.Name = "Business Tax Renew";
            fee2.Rate = 1000;
            fee2.isQuarterly = true;
            fee2.isActive = true;
            fee2.withInterest = false;
            fee2.UniqueId = Guid.NewGuid();
            fee2.CreatedBy = 1;
            fee2.CreatedDate = DateTime.Now;
            fee2.Status = stat2;

            Fee fee3 = new Fee();
            fee3.Name = "Mayor's Fee";
            fee3.Rate = 500;
            fee3.isQuarterly = false;
            fee3.isActive = true;
            fee3.withInterest = false;
            fee3.UniqueId = Guid.NewGuid();
            fee3.CreatedBy = 1;
            fee3.CreatedDate = DateTime.Now;
            fee3.Status = stat3;

            Fee fee4 = new Fee();
            fee4.Name = "Garbage Fee";
            fee4.Rate = 200;
            fee4.isQuarterly = false;
            fee4.isActive = true;
            fee4.withInterest = false;
            fee4.UniqueId = Guid.NewGuid();
            fee4.CreatedBy = 1;
            fee4.CreatedDate = DateTime.Now;
            fee4.Status = stat3;

            Fee fee5 = new Fee();
            fee5.Name = "Mechanical Fee";
            fee5.Rate = 250;
            fee5.isQuarterly = false;
            fee5.isActive = true;
            fee5.withInterest = false;
            fee5.UniqueId = Guid.NewGuid();
            fee5.CreatedBy = 1;
            fee5.CreatedDate = DateTime.Now;
            fee5.Status = stat3;

            Fee fee6 = new Fee();
            fee6.Name = "Plumbing Fee";
            fee6.Rate = 230;
            fee6.isQuarterly = false;
            fee6.isActive = true;
            fee6.withInterest = false;
            fee6.UniqueId = Guid.NewGuid();
            fee6.CreatedBy = 1;
            fee6.CreatedDate = DateTime.Now;
            fee6.Status = stat3;

            Fee fee7 = new Fee();
            fee7.Name = "Electrical Fee";
            fee7.Rate = 400;
            fee7.isQuarterly = false;
            fee7.isActive = true;
            fee7.withInterest = false;
            fee7.UniqueId = Guid.NewGuid();
            fee7.CreatedBy = 1;
            fee7.CreatedDate = DateTime.Now;
            fee7.Status = stat3;

            Fee fee8 = new Fee();
            fee8.Name = "Sticker Fee";
            fee8.Rate = 100;
            fee8.isQuarterly = false;
            fee8.isActive = true;
            fee8.withInterest = false;
            fee8.UniqueId = Guid.NewGuid();
            fee8.CreatedBy = 1;
            fee8.CreatedDate = DateTime.Now;
            fee8.Status = stat3;
            //FEE -- END

            //REQUIREMENTS -- START
            Requirement req1 = new Requirement();
            req1.Name = "Barangay Clearance";
            req1.Status = stat1;
            req1.UniqueId = Guid.NewGuid();
            req1.IsActive = true;
            req1.CreatedBy = 1;
            req1.CreatedDate = DateTime.Now;

            Requirement req2 = new Requirement();
            req2.Name = "Authorization Letter of Owner and ID";
            req2.Status = stat3;
            req2.UniqueId = Guid.NewGuid();
            req2.IsActive = true;
            req2.CreatedBy = 1;
            req2.CreatedDate = DateTime.Now;

            Requirement req3 = new Requirement();
            req3.Name = "Lease Contract / Tax Declaration";
            req3.Status = stat3;
            req3.UniqueId = Guid.NewGuid();
            req3.IsActive = true;
            req3.CreatedBy = 1;
            req3.CreatedDate = DateTime.Now;

            Requirement req4 = new Requirement();
            req4.Name = "SSS (Certification / Clearance)";
            req4.Status = stat3;
            req4.UniqueId = Guid.NewGuid();
            req4.IsActive = true;
            req4.CreatedBy = 1;
            req4.CreatedDate = DateTime.Now;

            Requirement req5 = new Requirement();
            req5.Name = "CTC (Community Tax Certificate)";
            req5.Status = stat3;
            req5.UniqueId = Guid.NewGuid();
            req5.IsActive = true;
            req5.CreatedBy = 1;
            req5.CreatedDate = DateTime.Now;

            Requirement req6 = new Requirement();
            req6.Name = "Public Liability Insurance";
            req6.Status = stat2;
            req6.UniqueId = Guid.NewGuid();
            req6.IsActive = true;
            req6.CreatedBy = 1;
            req6.CreatedDate = DateTime.Now;

            Requirement req7 = new Requirement();
            req7.Name = "SEC Registration";
            req7.Status = stat2;
            req7.UniqueId = Guid.NewGuid();
            req7.IsActive = true;
            req7.CreatedBy = 1;
            req7.CreatedDate = DateTime.Now;

            Requirement req8 = new Requirement();
            req8.Name = "DTI";
            req8.Status = stat2;
            req8.UniqueId = Guid.NewGuid();
            req8.IsActive = true;
            req8.CreatedBy = 1;
            req8.CreatedDate = DateTime.Now;
            //REQUIREMENTS -- END

            BusinessRecord br = new BusinessRecord();
            br.Barangay = bar1;
            br.BlockNo = 1;
            br.BuildingName = "adwa";
            br.BusinessDetail = bd1;
            br.BusinessName = "Mayaman Corp.";
            br.BusinessOwner = bo2;
            br.BusinessType = bt3;
            br.City = city1;
            br.Province = prov1;
			br.District = dist1;
            br.StartDate = DateTime.Now;
            br.Street = st1;
            br.StreetNo = 1;
            br.UniqueId = Guid.NewGuid();
            br.isActive = true;
            br.isAssessed = 0;
            br.isCollected = 0;
            br.isRetired = false;
            br.Address = "adwad";
            br.ContactNo = "12313";
            br.FaxNo = "2131";
            br.FloorNo = 2;
            br.Requirements.Add(req1);
            br.Requirements.Add(req2);

            context.BusinessNatures.AddOrUpdate(bn1, bn2, bn3, bn4, bn5);
            context.BusinessLines.AddOrUpdate(bl1, bl2, bl3, bl4, bl5);
            context.BusinessDetails.AddOrUpdate(bd1, bd2);
            context.BusinessOwners.AddOrUpdate(bo1, bo2);
            context.BusinessTypes.AddOrUpdate(bt1, bt2, bt3);
            context.BankRecords.AddOrUpdate(bank1, bank2);
            context.Provinces.AddOrUpdate(prov1, prov2);
            context.Cities.AddOrUpdate(city1, city2, city3, city4);
            context.Districts.AddOrUpdate(dist1, dist2, dist3, dist4);
            context.Barangays.AddOrUpdate(bar1, bar2, bar3, bar4);
            context.Streets.AddOrUpdate(st1, st2);
            context.Quarters.AddOrUpdate(qrt1, qrt2, qrt3, qrt4);
            context.Cutoffs.AddOrUpdate(cut1, cut2, cut3, cut4);
            context.Statuses.AddOrUpdate(stat1, stat2, stat3);
            context.Fees.AddOrUpdate(fee1, fee2, fee3, fee4, fee5, fee6, fee7, fee8);
            context.Requirements.AddOrUpdate(req1, req2, req3, req4, req5, req6, req7, req8);
            context.BusinessRecords.AddOrUpdate(br);
        }
    }
}
