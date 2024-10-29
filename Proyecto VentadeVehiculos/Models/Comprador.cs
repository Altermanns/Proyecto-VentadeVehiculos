using System.ComponentModel.DataAnnotations;

namespace Proyecto_VentadeVehiculos.Models
{
    public class Comprador
    {
        [Required]
        [Key]
        public int IdComprador { get; set; }
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
