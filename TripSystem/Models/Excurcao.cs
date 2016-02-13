using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TripSystem.Models
{
    public class Excurcao
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        public int GeneroId { get; set; }
        public int GuiaId { get; set; }

        [Required(ErrorMessage = "Titulo é obrigatório")]
        [StringLength(160)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Local de partida é obrigatório")]
        [DisplayName("Local de partida")]
        public string LocalPartida { get; set; }

        [Required(ErrorMessage = "Data de partida é obrigatório")]
        [DisplayName("Data de partida")]
        public DateTime DataParida { get; set; }

        [Required(ErrorMessage = "Numero de pessoas é obrigatório")]
        public int NumeroPessoas { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        public decimal Preco { get; set; }

        [DisplayName("URL da imagem")]
        public string ExcurcaoArtUrl { get; set; }

        public virtual Genero Genero { get; set; }
        public virtual Guia Guia { get; set; }
        public virtual List<ItensOrdem> ItensOrdem { get; set; }

    }
}