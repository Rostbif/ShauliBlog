namespace ShauliBlogMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecommentandfan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "Author_ID", c => c.Int());
            AddColumn("dbo.Fan", "Site", c => c.String());
            CreateIndex("dbo.Comment", "Author_ID");
            AddForeignKey("dbo.Comment", "Author_ID", "dbo.Fan", "ID");
            DropColumn("dbo.Comment", "AuthorName");
            DropColumn("dbo.Comment", "SiteOfAuthor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "SiteOfAuthor", c => c.String());
            AddColumn("dbo.Comment", "AuthorName", c => c.String());
            DropForeignKey("dbo.Comment", "Author_ID", "dbo.Fan");
            DropIndex("dbo.Comment", new[] { "Author_ID" });
            DropColumn("dbo.Fan", "Site");
            DropColumn("dbo.Comment", "Author_ID");
        }
    }
}
