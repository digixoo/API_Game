namespace Back.Migrations
{
    using Back.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Back.Models.CatalogoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Back.Models.CatalogoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //Parametros
            var generos = new List<Genero>()
            {
                new Genero() { Id = 1, Nombre = "RPG", Descripcion = "Roll Playing Game" },
                new Genero() { Id = 2, Nombre = "FPS", Descripcion = "First Person Shooter" },
                new Genero() { Id = 3, Nombre = "TPS", Descripcion = "Third Person Shooter" }
            };

            context.Generos.AddRange(generos);
            context.Juegos.AddOrUpdate(x => x.Id,
                new Juego() { Id = 1, Nombre = "Call of Duty", TipoGenero = generos.Where(g => g.Id == 1).First() }
                );
        }
    }
}
