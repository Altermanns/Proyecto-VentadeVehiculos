using System.ComponentModel.DataAnnotations;

namespace Proyecto_VentadeVehiculos.Models
{
    public class Vendedor
    {
        [Required]
        [Key]
        public int IdVendedor { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress]
        public string correo { get; set; }
        [DataType(DataType.Date)]
        public DateOnly fechanacimiento { get; set; }
        
    }

}
