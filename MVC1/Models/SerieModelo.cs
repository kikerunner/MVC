using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC1.Models
{
    public class SerieModelo
    {
        public int ID { get; set; }
        public string Nom_serie { get; set; }
        public MarcaModelo Marca { get; set; }
        public int MarcaID { get; set; }
        public List<VehiculoModelo> Vehiculos { get; set; }
        public List<int> VehiculosLista { get; set; }
    }
}