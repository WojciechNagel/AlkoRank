namespace WebApplication11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Whiskies",
                c => new
                    {
                        WhiskyID = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Kategoria = c.String(),
                        Oko = c.String(),
                        Nos = c.String(),
                        Język = c.String(),
                        Finisz = c.String(),
                        Cena = c.String(),
                    })
                .PrimaryKey(t => t.WhiskyID);
            
            CreateTable(
                "dbo.Winoes",
                c => new
                    {
                        WinoId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        DataProdukcji = c.DateTime(nullable: false),
                        Ocena = c.Int(nullable: false),
                        Cena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WinoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Winoes");
            DropTable("dbo.Whiskies");
        }
    }
}
