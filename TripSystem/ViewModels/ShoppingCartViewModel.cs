using System.Collections.Generic;
using TripSystem.Models;

namespace TripSystem.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Carrinho> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}