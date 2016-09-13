namespace ShauliBlogMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbirthdatefan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fan", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Fan", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fan", "Address");
            DropColumn("dbo.Fan", "BirthDate");
        }
    }
}
