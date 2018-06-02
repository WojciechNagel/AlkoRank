namespace WebApplication11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whiskydodanoocene : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Whiskies", "Ocena", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Whiskies", "Ocena");
        }
    }
}
