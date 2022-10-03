namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blog3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "TagsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "TagsId");
            AddForeignKey("dbo.Articles", "TagsId", "dbo.Tags", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "TagsId", "dbo.Tags");
            DropIndex("dbo.Articles", new[] { "TagsId" });
            DropColumn("dbo.Articles", "TagsId");
        }
    }
}
