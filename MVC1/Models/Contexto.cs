using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC1.Models
{
    public class Contexto : DbContext
    {
        public DbSet<MarcaModelo> Marcas { get; set; }
        public DbSet<SerieModelo> Series { get; set; }
        public DbSet<VehiculoModelo> Vehiculos { get; set; }
        public DbSet<ExtraModelo> Extras { get; set; }
        public DbSet<VehiculoExtrasModelo> VehiculosExtras { get; set; }
    }
}