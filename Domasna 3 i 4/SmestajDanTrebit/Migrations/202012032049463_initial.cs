namespace SmestajDanTrebit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accomodations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Name = c.String(),
                        InternationalName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accomodations");
        }
    }
}
