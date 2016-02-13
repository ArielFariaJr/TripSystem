using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripSystem.Models
{
    public class Genero
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public List<Excurcao> Excurcao { get; set; }

    }
}