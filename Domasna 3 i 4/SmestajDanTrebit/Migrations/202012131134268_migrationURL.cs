namespace SmestajDanTrebit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationURL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accomodations", "URL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accomodations", "URL");
        }
    }
}
