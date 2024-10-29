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
        public virtual Vendedor Vendedor { get; set; }

        [Required]
        [ForeignKey("Comprador")]
        public int IdComprador { get; set; }
        public virtual Comprador Comprador { get; set; }

        [Required]
        [ForeignKey("Vehiculo")]
        public int IdVehiculo { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaTransaccion { get; set; }

        [Required]
        public double PrecioFinal { get; set; }
    }
}

