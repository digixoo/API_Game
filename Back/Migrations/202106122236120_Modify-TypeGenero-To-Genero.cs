namespace Back.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTypeGeneroToGenero : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TipoGeneroes", newName: "Gereroes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Gereroes", newName: "TipoGeneroes");
        }
    }
}
