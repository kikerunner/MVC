using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC1.Models
{
    public class VehiculoExtrasModelo
    {
        public int ID { get; set; }

        public int vehiculoID { get; set; }
        public VehiculoModelo Vehiculo { get; set; }

        public int extraID { get; set; }
        public ExtraModelo Extra { get; set; }
    }
}