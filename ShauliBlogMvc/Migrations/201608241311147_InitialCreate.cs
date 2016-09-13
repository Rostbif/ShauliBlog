namespace ShauliBlogMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        Title = c.String(),
                        AuthorName = c.String(),
                        SiteOfAuthor = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Post", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        SiteOfAuthor = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        Image = c.Binary(),
                        video = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Fan",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Sex = c.String(),
                        Seniority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "PostID", "dbo.Post");
            DropIndex("dbo.Comment", new[] { "PostID" });
            DropTable("dbo.Fan");
            DropTable("dbo.Post");
            DropTable("dbo.Comment");
        }
    }
}
