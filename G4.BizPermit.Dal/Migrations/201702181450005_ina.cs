namespace G4.BizPermit.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ina : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UniqueId = c.Guid(nullable: false),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Barangays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueId = c.Guid(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueId = c.Guid(nullable: false),
                        CityId = c.Int(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueId = c.Guid(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueId = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BusinessDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueId = c.Guid(nullable: false),
                        Name = c.String(),
                        BusinessLineId = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Capital = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Gross = c.Decimal(nullable: false, precision: 18, scale: 2),
                        isNew = c.Boolean(nullable: false),
                        lastPayDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessLines", t => t.BusinessLineId, cascadeDelete: true)
                .Index(t => t.BusinessLineId);
            
            CreateTable(
                "dbo.BusinessLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueId = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        BusinessNatureId = c.Int(nullable: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessNatures", t => t.BusinessNatureId, cascadeDelete: true)
                .Index(t => t.BusinessNatureId);
            
            CreateTable(
                "dbo.BusinessNatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueId = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        BusinessNatureName = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BusinessOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueId = c.Guid(nullable: false),
                        Designation = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        Gender = c.String(),
                        MaritalStatus = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        CorporateName = c.String(),
                        Address = c.String(),
                        ContactNo = c.String(),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BusinessRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueId = c.Guid(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        BusinessName = c.String(),
                        BusinessDetailId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        ContactNo = c.String(),
                        FaxNo = c.String(),
                        ProvinceId = c.Int(),
                        CityId = c.Int(),
                        DistrictId = c.Int(),
                        BarangayId = c.Int(),
                        StreetId = c.Int(),
                        StreetNo = c.Int(nullable: false),
                        BlockNo = c.Int(nullable: false),
                        Address = c.String(),
                        BuildingName = c.String(),
                        FloorNo = c.Int(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        BusinessTypeId = c.Int(nullable: false),
                        isRetired = c.Boolean(nullable: false),
                        isAssessed = c.Boolean(nullable: false),
                        isPayed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Barangays", t => t.BarangayId)
                .ForeignKey("dbo.BusinessDetails", t => t.BusinessDetailId, cascadeDelete: true)
                .ForeignKey("dbo.BusinessOwners", t => t.OwnerId, cascadeDelete: true)
                .ForeignKey("dbo.BusinessTypes", t => t.BusinessTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Districts", t => t.DistrictId)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId)
                .ForeignKey("dbo.Streets", t => t.StreetId)
                .Index(t => t.OwnerId)
                .Index(t => t.BusinessDetailId)
                .Index(t => t.ProvinceId)
                .Index(t => t.CityId)
                .Index(t => t.DistrictId)
                .Index(t => t.BarangayId)
                .Index(t => t.StreetId)
                .Index(t => t.BusinessTypeId);
            
            CreateTable(
                "dbo.BusinessTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueId = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Requirements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueId = c.Guid(nullable: false),
                        Name = c.String(),
                        StatusId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueId = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueId = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        BarangayId = c.Int(nullable: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Barangays", t => t.BarangayId, cascadeDelete: true)
                .Index(t => t.BarangayId);
            
            CreateTable(
                "dbo.Cutoffs",
                c => new
                    {
                        UniqueId = c.Guid(nullable: false),
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CuttoffDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UniqueId);
            
            CreateTable(
                "dbo.Fees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueId = c.Guid(nullable: false),
                        Name = c.String(),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        isQuarterly = c.Boolean(nullable: false),
                        StatusId = c.Int(nullable: false),
                        withInterest = c.Boolean(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Quarters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        firstQtr = c.Boolean(nullable: false),
                        secondQtr = c.Boolean(nullable: false),
                        thirdQtr = c.Boolean(nullable: false),
                        fourthQtr = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequirementBusinessRecords",
                c => new
                    {
                        Requirement_Id = c.Int(nullable: false),
                        BusinessRecord_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Requirement_Id, t.BusinessRecord_Id })
                .ForeignKey("dbo.Requirements", t => t.Requirement_Id, cascadeDelete: true)
                .ForeignKey("dbo.BusinessRecords", t => t.BusinessRecord_Id, cascadeDelete: true)
                .Index(t => t.Requirement_Id)
                .Index(t => t.BusinessRecord_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fees", "StatusId", "dbo.Status");
            DropForeignKey("dbo.BusinessRecords", "StreetId", "dbo.Streets");
            DropForeignKey("dbo.Streets", "BarangayId", "dbo.Barangays");
            DropForeignKey("dbo.Requirements", "StatusId", "dbo.Status");
            DropForeignKey("dbo.RequirementBusinessRecords", "BusinessRecord_Id", "dbo.BusinessRecords");
            DropForeignKey("dbo.RequirementBusinessRecords", "Requirement_Id", "dbo.Requirements");
            DropForeignKey("dbo.BusinessRecords", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.BusinessRecords", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.BusinessRecords", "CityId", "dbo.Cities");
            DropForeignKey("dbo.BusinessRecords", "BusinessTypeId", "dbo.BusinessTypes");
            DropForeignKey("dbo.BusinessRecords", "OwnerId", "dbo.BusinessOwners");
            DropForeignKey("dbo.BusinessRecords", "BusinessDetailId", "dbo.BusinessDetails");
            DropForeignKey("dbo.BusinessRecords", "BarangayId", "dbo.Barangays");
            DropForeignKey("dbo.BusinessDetails", "BusinessLineId", "dbo.BusinessLines");
            DropForeignKey("dbo.BusinessLines", "BusinessNatureId", "dbo.BusinessNatures");
            DropForeignKey("dbo.Barangays", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.RequirementBusinessRecords", new[] { "BusinessRecord_Id" });
            DropIndex("dbo.RequirementBusinessRecords", new[] { "Requirement_Id" });
            DropIndex("dbo.Fees", new[] { "StatusId" });
            DropIndex("dbo.Streets", new[] { "BarangayId" });
            DropIndex("dbo.Requirements", new[] { "StatusId" });
            DropIndex("dbo.BusinessRecords", new[] { "BusinessTypeId" });
            DropIndex("dbo.BusinessRecords", new[] { "StreetId" });
            DropIndex("dbo.BusinessRecords", new[] { "BarangayId" });
            DropIndex("dbo.BusinessRecords", new[] { "DistrictId" });
            DropIndex("dbo.BusinessRecords", new[] { "CityId" });
            DropIndex("dbo.BusinessRecords", new[] { "ProvinceId" });
            DropIndex("dbo.BusinessRecords", new[] { "BusinessDetailId" });
            DropIndex("dbo.BusinessRecords", new[] { "OwnerId" });
            DropIndex("dbo.BusinessLines", new[] { "BusinessNatureId" });
            DropIndex("dbo.BusinessDetails", new[] { "BusinessLineId" });
            DropIndex("dbo.Cities", new[] { "ProvinceId" });
            DropIndex("dbo.Districts", new[] { "CityId" });
            DropIndex("dbo.Barangays", new[] { "DistrictId" });
            DropTable("dbo.RequirementBusinessRecords");
            DropTable("dbo.Quarters");
            DropTable("dbo.Fees");
            DropTable("dbo.Cutoffs");
            DropTable("dbo.Streets");
            DropTable("dbo.Status");
            DropTable("dbo.Requirements");
            DropTable("dbo.BusinessTypes");
            DropTable("dbo.BusinessRecords");
            DropTable("dbo.BusinessOwners");
            DropTable("dbo.BusinessNatures");
            DropTable("dbo.BusinessLines");
            DropTable("dbo.BusinessDetails");
            DropTable("dbo.Provinces");
            DropTable("dbo.Cities");
            DropTable("dbo.Districts");
            DropTable("dbo.Barangays");
            DropTable("dbo.Banks");
        }
    }
}
