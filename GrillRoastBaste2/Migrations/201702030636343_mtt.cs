namespace GrillRoastBaste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mtt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerSubmitions",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SurName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        EventDescription = c.String(nullable: false),
                        DateOfBooking = c.DateTime(nullable: false),
                        DateOfEvent = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerSubmitions");
        }
    }
}
