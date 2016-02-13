using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc.Html;

namespace TripSystem.Models
{
    public class Contato
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Seu nome é obrigatório")]
        public string Nome { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Seu e-mail é obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Endereço de email invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O assunto é obrigatório")]
        public string Assunto { get; set; }
        
        [Required(ErrorMessage = "A mensagem é obrigatória")]
        [DisplayName("Deixe sua mensagem:")]
        public string Mensagem { get; set; }        

    }
}