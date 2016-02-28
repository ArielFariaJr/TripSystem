using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TripSystem.Models
{
    public partial class ShoppingCart
    {
        SystemEntities storeDB = new SystemEntities();

        string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        // Método para simplifcar a chamado do carrinho de compras
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Excurcao excurcao, int quantidade)
        {
            // Get the matching cart and album instances
            var cartItem = storeDB.Carrinho.SingleOrDefault(c => c.CarrinhoId == ShoppingCartId
                            && c.ExcurcaoId == excurcao.ID);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Carrinho
                {
                    ExcurcaoId = excurcao.ID,
                    CarrinhoId = ShoppingCartId,
                    Count = quantidade,
                    DateCreated = DateTime.Now
                };

                storeDB.Carrinho.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.Count++;
            }

            // Save changes
            storeDB.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = storeDB.Carrinho.Single(cart => cart.CarrinhoId == ShoppingCartId
                                                && cart.RecordId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    storeDB.Carrinho.Remove(cartItem);
                }

                // Save changes
                storeDB.SaveChanges();
            }

            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = storeDB.Carrinho.Where(cart => cart.CarrinhoId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                storeDB.Carrinho.Remove(cartItem);
            }

            // Save changes
            storeDB.SaveChanges();
        }

        public List<Carrinho> GetCartItems()
        {
            return storeDB.Carrinho.Where(cart => cart.CarrinhoId == ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in storeDB.Carrinho
                          where cartItems.CarrinhoId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();

            // Return 0 if all entries are null
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = (from cartItems in storeDB.Carrinho
                              where cartItems.CarrinhoId == ShoppingCartId
                              select (int?)cartItems.Count * cartItems.Excurcao.Preco).Sum();
            return total ?? decimal.Zero;
        }

        public int CreateOrder(Ordem order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            // Iterate over the items in the cart, adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new ItensOrdem
                {
                    ExcurcaoId = item.ExcurcaoId,
                    IdOrdem = order.OrdemId,
                    PrecoUnitario = item.Excurcao.Preco,
                    Quantidade = item.Count
                };

                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Excurcao.Preco);

                storeDB.ItensOrdem.Add(orderDetail);

            }

            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            // Save the order
            storeDB.SaveChanges();

            // Empty the shopping cart
            EmptyCart();

            // Return the OrderId as the confirmation number
            return order.OrdemId;
        }

        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();

                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = storeDB.Carrinho.Where(c => c.CarrinhoId == ShoppingCartId);

            foreach (Carrinho item in shoppingCart)
            {
                item.CarrinhoId = userName;
            }
            storeDB.SaveChanges();
        }
    }
}