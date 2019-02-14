using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC1.Models
{
    public class VehiculoModelo
    {
        public int ID { get; set; }
        public string Matricula { get; set; }
        public string Color { get; set; }
        public SerieModelo Serie { get; set; }
        public int SerieID { get; set; }

        public List<VehiculoExtrasModelo> VehiculoExtras { get; set; }
        public List<int> ExtrasSeleccionados { get; set; }
    }
}