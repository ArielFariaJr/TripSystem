using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.Entity;


namespace TripSystem.Models
{
    public class Reserva
    {
        [Key, Column(Order = 1)]
        public int OrdemId { get; set; }
        
        [Key, Column(Order = 3)]
        [ScaffoldColumn(false)]
        public int passageiroID { get; set; }

        public int ExcurcaoId { get; set; }

        [ScaffoldColumn(false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Primeiro nome é obrigatório")]
        [StringLength(160)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório")]
        [DisplayName("Sobre nome")]
        [StringLength(160)]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório")]
        [DisplayName("Endereço")]
        [StringLength(160)]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Idade é obrigatório")]
        [DisplayName("Idade")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [DisplayName("Telefone")]
        [StringLength(160)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [DisplayName("Endereço de e-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
        ErrorMessage = "E-mail não é valido.")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public decimal PrecoUnitario { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }

        [ScaffoldColumn(false)]
        public string SessionID { get; set; }

        public virtual Excurcao Excurcao { get; set; }

    }
}