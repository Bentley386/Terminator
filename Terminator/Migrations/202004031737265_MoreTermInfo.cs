namespace TerminiDostave.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreTermInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TermModels", "TrackingNumber", c => c.Int(nullable: false));
            AddColumn("dbo.TermModels", "DeliveryNumber", c => c.Int(nullable: false));
            AddColumn("dbo.TermModels", "StorageId", c => c.Int(nullable: false));
            AddColumn("dbo.TermModels", "AcessPoint", c => c.Int(nullable: false));
            AddColumn("dbo.TermModels", "DeliveryTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.TermModels", "OpombeDostavljalca", c => c.String());
            AddColumn("dbo.TermModels", "OpombeZaposlenega", c => c.String());
            AlterColumn("dbo.TermModels", "Status", c => c.String());
            DropColumn("dbo.TermModels", "Delivery");
            DropColumn("dbo.TermModels", "ExtraInfo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TermModels", "ExtraInfo", c => c.String());
            AddColumn("dbo.TermModels", "Delivery", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TermModels", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.TermModels", "OpombeZaposlenega");
            DropColumn("dbo.TermModels", "OpombeDostavljalca");
            DropColumn("dbo.TermModels", "DeliveryTime");
            DropColumn("dbo.TermModels", "AcessPoint");
            DropColumn("dbo.TermModels", "StorageId");
            DropColumn("dbo.TermModels", "DeliveryNumber");
            DropColumn("dbo.TermModels", "TrackingNumber");
        }
    }
}
