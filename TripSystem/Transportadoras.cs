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
    
    public partial class Transportadoras
    {
        public Transportadoras()
        {
            this.Veiculoes = new HashSet<Veiculoes>();
        }
    
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    
        public virtual ICollection<Veiculoes> Veiculoes { get; set; }
    }
}
