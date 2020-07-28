namespace TerminiDostave.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TermModels", "Company", c => c.String(nullable: false));
            AlterColumn("dbo.TermModels", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.TermModels", "Lastname", c => c.String(nullable: false));
            AlterColumn("dbo.TermModels", "Telephone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TermModels", "Telephone", c => c.String());
            AlterColumn("dbo.TermModels", "Lastname", c => c.String());
            AlterColumn("dbo.TermModels", "FirstName", c => c.String());
            AlterColumn("dbo.TermModels", "Company", c => c.String());
        }
    }
}
