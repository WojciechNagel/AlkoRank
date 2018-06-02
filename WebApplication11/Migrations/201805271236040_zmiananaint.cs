namespace WebApplication11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmiananaint : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Winoes", "RokProdukcji", c => c.Int(nullable: false));
            DropColumn("dbo.Winoes", "DataProdukcji");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Winoes", "DataProdukcji", c => c.DateTime(nullable: false));
            DropColumn("dbo.Winoes", "RokProdukcji");
        }
    }
}
