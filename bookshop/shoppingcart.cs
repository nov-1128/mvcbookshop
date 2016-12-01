using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookshop
{
    public partial class shoppingcart
    {
        bookshopDB storeDB = new bookshopDB();
        string shoppingCartId { get; set; }
        public const string CratSessionKey = "CartId";
        public static shoppingcart GetCart(HttpContextBase context)
        {
            var carts = new shoppingcart();
            carts.shoppingCartId = carts.GetCartId(context);
            return carts;
        }
        public static shoppingcart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(book book)
        {
            var cartItem = storeDB.cart.SingleOrDefault(c => c.CartId == shoppingCartId && c.BookId == book.Id);
            if (cartItem == null)
            {
                cartItem = new cart
                {
                    BookId = book.Id,
                    CartId = shoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                storeDB.cart.Add(cartItem);
            }
            else {
                cartItem.Count++;
            }
            storeDB.SaveChanges();
        }
        [HttpGet]
        public int RemoveFromCart(int id)
        {
            var cartItem = storeDB.cart.Single(c => c.CartId == shoppingCartId && c.RecordId == id);
            int itemCount = 0;
            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else {
                    storeDB.cart.Remove(cartItem);
                }
                storeDB.SaveChanges();
            }
           
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItem = storeDB.cart.Where(c => c.CartId == shoppingCartId);
            foreach (var cartItems in cartItem)
            {
                storeDB.cart.Remove(cartItems);
            }
            storeDB.SaveChanges();
        }
        public List<cart> GetCartItems()
        {
            return storeDB.cart.Where(c => c.CartId == shoppingCartId).ToList();
        }
        public int GetCount()
        {
            int? counts = (from cartItems in storeDB.cart
                          where cartItems.CartId == shoppingCartId
                          select (int?)cartItems.Count).Sum();
            return counts ?? 0;
        }
        public decimal GetTotal()
        {
            decimal? totals = (from cartItems in storeDB.cart
                              where cartItems.CartId == shoppingCartId
                              select (int?)cartItems.Count * cartItems.book.Price).Sum();
            return totals ?? decimal.Zero;
        }
        public int CreateOrder(order orders)
        {
            decimal orderTotal = 0;
            var cartItems = GetCartItems();

            foreach (var items in cartItems)
            {
                var orderdetails = new orderdetail
                {
                    BookId = items.BookId,
                    OrderId = orders.OrderId,
                    UnitPrice = items.book.Price,
                    Quantity = items.Count
                };
                orderTotal += (items.Count * items.book.Price);
            }
            orders.Total = orderTotal;
            storeDB.SaveChanges();
            EmptyCart();
            return orders.OrderId;
        }
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CratSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CratSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CratSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CratSessionKey].ToString();
        }
        public void MigrateCart(string userName)
        {
            var shoppingCart = storeDB.cart.Where(c => c.CartId == shoppingCartId);
            foreach(cart item in shoppingCart)
            {
                item.CartId = userName;
            }
            storeDB.SaveChanges();
        }

    }

}