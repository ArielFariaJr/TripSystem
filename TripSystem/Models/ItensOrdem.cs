using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace TripSystem.Models
{
    public class ItensOrdem
    {   [Key]
        public int IdOrdemDetalhe { get; set; }
        public int IdOrdem { get; set; }
        public int ExcurcaoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public virtual Excurcao Excurcao { get; set; }
        public virtual Ordem Ordem { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }
    }
}