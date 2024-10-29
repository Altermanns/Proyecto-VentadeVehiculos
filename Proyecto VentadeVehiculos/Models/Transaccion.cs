using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_VentadeVehiculos.Models
{
    public class Transaccion
    { 
        [Required]
        [Key]
        public int IdTransaccion { get; set; }

        [Required]
        [ForeignKey("Vendedor")]
        public int IdVendedor { get; set; }
        public Vendedor? Vendedor { get; set; }

        [Required]
        [ForeignKey("Comprador")]
        public int IdComprador { get; set; }
        public  Comprador? Comprador { get; set; }

        [Required]
        [ForeignKey("Vehiculo")]
        public int IdVehiculo { get; set; }
        public  Vehiculo? Vehiculo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaTransaccion { get; set; }

        [Required]
        public double PrecioFinal { get; set; }
    }
}

