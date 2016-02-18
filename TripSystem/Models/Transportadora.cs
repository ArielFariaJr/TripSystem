using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TripSystem.Models
{
    public class Transportadora
    {
        [ScaffoldColumn(false)]
        public int    ID     {get; set;}

        [Required(ErrorMessage = "O nome da transportadora é obrigatório")]
        [StringLength(160)]
        [DisplayName("Nome da transportadora")]
        public string Nome   {get; set;}

        [Required(ErrorMessage = "O CNPJ da transportadora é obrigatório")]
        [StringLength(18)]
        public string CNPJ   {get; set;}

        [Required(ErrorMessage = "A Inscrição da transportadora é obrigatório")]
        [StringLength(10)]
        [DisplayName("Inscrição estadual")]
        public string IE     {get; set;}

        [Required(ErrorMessage = "O endereço transportadora é obrigatório")]
        [StringLength(160)]
        public string Rua    {get; set;}

        [Required(ErrorMessage = "O endereço da transportadora é obrigatório")]
        public int    Numero {get; set;}

        [Required(ErrorMessage = "O endereço da transportadora é obrigatório")]
        [StringLength(100)]
        public string Bairro {get; set;}

        [StringLength(9)]
        public string CEP    {get; set;}

        [Required(ErrorMessage = "O endereço da transportadora é obrigatório")]
        [StringLength(50)]
        public string Cidade {get; set;}

        [Required(ErrorMessage = "O endereço da transportadora é obrigatório")]
        [StringLength(20)]
        public string Estado {get; set;}

    }
}