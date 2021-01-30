using System;
using System.Collections.Generic;

namespace handson.c.sharp.chapter3
{
    public class Order
    {
        private readonly List<OrderItem> items = new List<OrderItem>();

        public string OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> Items { get { return items; } }

        public Order()
        {
        }
    }
}
