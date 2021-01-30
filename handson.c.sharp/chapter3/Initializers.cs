using System;
namespace handson.c.sharp.chapter3
{
    public class Initializers
    {
        static void Main(string[] args)
        {

            var order = new Order
            {
                OrderId = "abc",
                Customer = new Customer { FirstName = "Dina", LastName = "Bogdan" },
                Items =
                {
                    new OrderItem { OrderId = "1", Quantity = 10},
                    new OrderItem { OrderId = "2", Quantity = 25}
                }
            };

            Console.WriteLine(order.Customer.FirstName);

        }
    }
}
