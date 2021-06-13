namespace Back.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CatalogoContext : DbContext, ICatalogoContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'ClientesContext' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'Back.Models.ClientesContext' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'ClientesContext'  en el archivo de configuración de la aplicación.
        public CatalogoContext() : base("name=ClientesContext")
        {
        }

        public CatalogoContext(string connectionString) : base(connectionString)
        {

        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Juego> Juegos { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
    }
}
   