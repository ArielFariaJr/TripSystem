//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TripSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ordems
    {
        public Ordems()
        {
            this.ItensOrdems = new HashSet<ItensOrdems>();
        }
    
        public int OrdemId { get; set; }
        public int OrdemItem { get; set; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Endereco { get; set; }
        public int Idade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public System.DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
    
        public virtual ICollection<ItensOrdems> ItensOrdems { get; set; }
    }
}
