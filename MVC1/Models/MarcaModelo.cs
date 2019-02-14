using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC1.Models
{
    public class MarcaModelo
    {
        public int ID { get; set; }
        public string Nom_marca { get; set; }
        public List<SerieModelo> Series { get; set; }
    }
}