using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TripSystem.Models
{
    public class Excurcao
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [ForeignKey("Genero")]
        public int GeneroId { get; set; }
        [ForeignKey("Guia")]
        public int GuiaId { get; set; }
        [ForeignKey("Veiculo")]
        public int VeicuiloId { get; set; }

        [Required(ErrorMessage = "Titulo é obrigatório")]
        [StringLength(160)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Local de partida é obrigatório")]
        [DisplayName("Local de partida")]
        public string LocalPartida { get; set; }

        [Required(ErrorMessage = "Data de partida é obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:-dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Data de partida")]
        public DateTime DataPartida { get; set; }

        [Required(ErrorMessage = "Data de retorno é obrigatório")]
        [DisplayName("Data de retorno")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:-dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataRetorno { get; set; }

        [Required(ErrorMessage = "Numero de pessoas é obrigatório")]
        [DisplayName("Numero de pessoas")]
        public int NumeroPessoas { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        public decimal Preco { get; set; }

        [DisplayName("URL da imagem")]
        public string ExcurcaoArtUrl { get; set; }

        public virtual Genero Genero { get; set; }
        public virtual Guia Guia { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        public virtual List<ItensOrdem> ItensOrdem { get; set; }

    }
}