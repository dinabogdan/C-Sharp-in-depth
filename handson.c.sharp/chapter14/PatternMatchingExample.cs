using System;
namespace handson.c.sharp.chapter14
{
    public class PatternMatchingExample
    {

        static void Greet(Customer customer)
        {
            string greeting = customer switch
            {
                { Address: { Country: "UK" } } => "Welcome, customer from the United Kingdom!",
                { Address: { Country: "USA" } } => "Welcome, customer from the USA!",
                { Address: { Country: string country } } => $"Welcome, customer from {country}!",
                { Address: { } } => "Welcome, customer whose address has no country!",
                { } => "Welcome, customer of an unknown address!",
                _ => "Welcome, nullness my old friend!"
            };
            Console.WriteLine(greeting);
        }


        static void Main()
        {
            Customer customer = new Customer
            {
                Address = new Address { Country = "USA" }
            };

            Greet(customer);
        }
    }
}
