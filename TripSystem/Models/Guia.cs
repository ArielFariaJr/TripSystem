using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripSystem.Models
{
    public class Guia
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(160)]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:-dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Idade é obrigatório")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O campo Sexo é obrigatório")]
        [StringLength(50)]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [StringLength(14)]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Titulo é obrigatório")]
        [DisplayName("RG")]
        [StringLength(12)]
        public string Rg { get; set; }

    }
}