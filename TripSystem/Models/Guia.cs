using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripSystem.Models
{
    public class Guia
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Idade { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }

    }
}