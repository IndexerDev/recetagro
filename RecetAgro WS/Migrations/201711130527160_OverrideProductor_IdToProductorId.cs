namespace RecetAgro_WS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideProductor_IdToProductorId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Huertos", "Productor_Id", "dbo.Productores");
            DropIndex("dbo.Huertos", new[] { "Productor_Id" });
            RenameColumn(table: "dbo.Huertos", name: "Productor_Id", newName: "ProductorId");
            AlterColumn("dbo.Huertos", "ProductorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Huertos", "ProductorId");
            AddForeignKey("dbo.Huertos", "ProductorId", "dbo.Productores", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Huertos", "ProductorId", "dbo.Productores");
            DropIndex("dbo.Huertos", new[] { "ProductorId" });
            AlterColumn("dbo.Huertos", "ProductorId", c => c.Int());
            RenameColumn(table: "dbo.Huertos", name: "ProductorId", newName: "Productor_Id");
            CreateIndex("dbo.Huertos", "Productor_Id");
            AddForeignKey("dbo.Huertos", "Productor_Id", "dbo.Productores", "Id");
        }
    }
}
