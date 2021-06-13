namespace Back.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioDeNombre : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Gereroes", newName: "Generoes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Generoes", newName: "Gereroes");
        }
    }
}
