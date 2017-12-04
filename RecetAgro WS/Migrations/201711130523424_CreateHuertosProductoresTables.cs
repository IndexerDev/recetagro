namespace RecetAgro_WS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateHuertosProductoresTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Huertos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Sagarpa = c.String(nullable: false, maxLength: 14),
                        Ubicacion = c.String(maxLength: 30),
                        Productor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productores", t => t.Productor_Id)
                .Index(t => t.Productor_Id);
            
            CreateTable(
                "dbo.Productores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        ApellidoPaterno = c.String(nullable: false, maxLength: 50),
                        ApellidoMaterno = c.String(maxLength: 50),
                        Telefono = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Huertos", "Productor_Id", "dbo.Productores");
            DropIndex("dbo.Huertos", new[] { "Productor_Id" });
            DropTable("dbo.Productores");
            DropTable("dbo.Huertos");
        }
    }
}
