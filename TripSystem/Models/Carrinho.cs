using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TripSystem.Models
{
    public class Carrinho
    {
        [Key]
        public int RecordId { get; set; }
        public string CarrinhoId { get; set; }
        public int ExcurcaoId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual Excurcao Excurcao { get; set; }

    }
}