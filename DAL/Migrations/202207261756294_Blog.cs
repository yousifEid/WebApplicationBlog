namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Topic = c.String(),
                        Photo = c.String(),
                        ReadTime = c.Int(nullable: false),
                        AuthorsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorsId, cascadeDelete: true)
                .Index(t => t.AuthorsId);
            
            CreateTable(
                "dbo.ArticleTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagsId = c.Int(nullable: false),
                        ArticlesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticlesId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagsId, cascadeDelete: true)
                .Index(t => t.TagsId)
                .Index(t => t.ArticlesId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Topic = c.String(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "AuthorsId", "dbo.Authors");
            DropForeignKey("dbo.ArticleTags", "TagsId", "dbo.Tags");
            DropForeignKey("dbo.ArticleTags", "ArticlesId", "dbo.Articles");
            DropIndex("dbo.ArticleTags", new[] { "ArticlesId" });
            DropIndex("dbo.ArticleTags", new[] { "TagsId" });
            DropIndex("dbo.Articles", new[] { "AuthorsId" });
            DropTable("dbo.Authors");
            DropTable("dbo.Tags");
            DropTable("dbo.ArticleTags");
            DropTable("dbo.Articles");
        }
    }
}
