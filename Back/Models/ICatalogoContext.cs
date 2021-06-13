using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Models
{
    public interface ICatalogoContext
    {
        DbSet<Juego> Juegos { get; set; }
        DbSet<Genero> Generos { get; set; }

        int SaveChanges();
    }
}
