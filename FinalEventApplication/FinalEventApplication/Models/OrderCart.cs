using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalEventApplication.Models
{
    public class OrderCart
    {
        private string OrderCartId;
        private const string OrderSessionKey = "OrderId";

        FinalEventApplicationDBContext db = new FinalEventApplicationDBContext();

        public static OrderCart GetCart(HttpContextBase context)
        {
            OrderCart cart = new OrderCart();
            cart.OrderCartId = cart.GetCartId(context);
            return cart;
        }

        public string GetCartId(HttpContextBase context)
        {
            string orderId;
            if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
            {
                orderId = context.User.Identity.Name;
                context.Session[OrderSessionKey] = orderId;
            }           
            else
            {
                 orderId = context.Session[OrderSessionKey].ToString();
            }
            return orderId;
        }

        public  List<Order> GetOrderItems()
        {
           return db.Orders.Where(a => a.OrderId == OrderCartId).ToList();
        }

        public void AddToCart(int id)
        {
            Order orderItem = db.Orders.SingleOrDefault(o => o.OrderId == OrderCartId && o.EventId == id);
            Event otherEvent = db.Events.SingleOrDefault(e => e.EventId == id);

            if(orderItem == null)
            {
                orderItem = new Order()
                {
                    OrderId = OrderCartId,
                    EventId = id,
                    EventSelected = otherEvent,
                    Count = 1,
                    DateCreated = DateTime.Now
                };

                db.Orders.Add(orderItem);
            }
            else
            {
                orderItem.Count++;
            }
            db.SaveChanges();
        }

    }
}