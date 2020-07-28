namespace TerminiDostave.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TermModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TermModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        FirstName = c.String(),
                        Lastname = c.String(),
                        Telephone = c.String(),
                        Delivery = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        ExtraInfo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TermModels");
        }
    }
}
