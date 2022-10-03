namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blog2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "ReadTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "ReadTime", c => c.Int(nullable: false));
        }
    }
}
