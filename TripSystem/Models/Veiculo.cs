using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TripSystem.Models
{
    public class Veiculo
    {
        [ScaffoldColumn(false)]
        public int VeiculoId { get; set; }
        public int TransportadoraId { get; set; }
        

        [Required(ErrorMessage = "A marca do carro é obrigatória")]
        [StringLength(30)]
        [DisplayName("Marca do veiculo")]
        public string MarcaCarro { get; set; }

        [Required(ErrorMessage = "O modelo do carro é obrigatório")]
        [StringLength(30)]
        [DisplayName("Modelo do veiculo")]
        public string ModeloCarro { get; set; }

        [Required(ErrorMessage = "A quantidade de passageiros é obrigatória")]
        [DisplayName("Quantidade de passageiros")]
        public int QntAssentos { get; set; }

        [Required(ErrorMessage = "O valor da diária é obrigatório")]
        [DisplayName("Valor da diaria")]
        public double ValorDiaria{ get; set; }

        public virtual Transportadora Transportadora { get; set; }

    }
}