using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TripSystem.ViewModels
{
    public class ListaDeEmbarque
    {
        public string Titulo { get; set; }
        public string LocalPartida { get; set; }
        public DateTime DataPartida { get; set; }
        public DateTime DataRetorno { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
        public int OrdemId { get; set; }
    }
}
