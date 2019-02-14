using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC1.Models
{
    public class ExtraModelo
    {
        public int ID { get; set; }
        public string Tipo_extra { get; set; }

        public List<VehiculoExtrasModelo> ExtraVehiculo { get; set; }
        public List<int> VehiculosSeleccionados { get; set; }
    }
}