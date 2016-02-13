using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TripSystem.Models
{
    public class Ordem
    {
        [Key]
        public int OrdemId { get; set; }
        public List<ItensOrdem> ItensOrdem { get; set; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Endereco { get; set; }
        public int Idade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public decimal Total { get; set; }
        public System.DateTime OrderDate { get; set; }        

    }
}