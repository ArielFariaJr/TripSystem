using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TripSystem.Models
{
    public class SystemEntities : DbContext
    {
        public DbSet<Excurcao> Excurcao { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Guia> Guia { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<Ordem> Ordem { get; set; }
        public DbSet<ItensOrdem> ItensOrdem { get; set; }
        public DbSet<Transportadora> Transportadora { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
    }
}