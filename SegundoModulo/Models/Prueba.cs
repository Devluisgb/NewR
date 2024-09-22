using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegundoModulo.Models
{
    public class Prueba
    {
        public int Id { get; set; }
        [MaxLength(255)] // Esto asegura que se use VARCHAR(255)
        public String? Nombre { get; set; }
        [Column(TypeName = "TEXT")] // Esto mapea Descripcion a TEXT
        public String? Descripcion { get; set; }

    }
}