namespace ShauliBlogMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addauthoridcomment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "Author_ID", "dbo.Fan");
            DropIndex("dbo.Comment", new[] { "Author_ID" });
            RenameColumn(table: "dbo.Comment", name: "Author_ID", newName: "AuthorID");
            AlterColumn("dbo.Comment", "AuthorID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "AuthorID");
            AddForeignKey("dbo.Comment", "AuthorID", "dbo.Fan", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "AuthorID", "dbo.Fan");
            DropIndex("dbo.Comment", new[] { "AuthorID" });
            AlterColumn("dbo.Comment", "AuthorID", c => c.Int());
            RenameColumn(table: "dbo.Comment", name: "AuthorID", newName: "Author_ID");
            CreateIndex("dbo.Comment", "Author_ID");
            AddForeignKey("dbo.Comment", "Author_ID", "dbo.Fan", "ID");
        }
    }
}
