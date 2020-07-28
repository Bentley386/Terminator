namespace TerminiDostave.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NvmCalendar : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.FreeTermModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FreeTermModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StorageId = c.Int(nullable: false),
                        AccessPoint = c.Int(nullable: false),
                        Day1 = c.String(),
                        Day2 = c.String(),
                        Day3 = c.String(),
                        Day4 = c.String(),
                        Day5 = c.String(),
                        Day6 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
