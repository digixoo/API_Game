namespace Back.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTipoGeneroOnJuego : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoGeneroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200),
                        Descripcion = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Juegoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200),
                        TipoGenero_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoGeneroes", t => t.TipoGenero_Id)
                .Index(t => t.TipoGenero_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Juegoes", "TipoGenero_Id", "dbo.TipoGeneroes");
            DropIndex("dbo.Juegoes", new[] { "TipoGenero_Id" });
            DropTable("dbo.Juegoes");
            DropTable("dbo.TipoGeneroes");
        }
    }
}
