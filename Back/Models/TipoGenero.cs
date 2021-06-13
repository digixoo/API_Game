using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class Genero
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

    }
}