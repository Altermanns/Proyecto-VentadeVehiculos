using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_VentadeVehiculos.Models;

namespace Proyecto_VentadeVehiculos.Data
{
    public class Proyecto_VentadeVehiculosContext : DbContext
    {
        public Proyecto_VentadeVehiculosContext (DbContextOptions<Proyecto_VentadeVehiculosContext> options)
            : base(options)
        {
        }

        public DbSet<Proyecto_VentadeVehiculos.Models.Comprador> Comprador { get; set; } = default!;
        public DbSet<Proyecto_VentadeVehiculos.Models.Vendedor> Vendedor { get; set; } = default!;
        public DbSet<Proyecto_VentadeVehiculos.Models.Vehiculo> Vehiculo { get; set; } = default!;
        public DbSet<Proyecto_VentadeVehiculos.Models.Transaccion> Transaccion { get; set; } = default!;
    }
}
