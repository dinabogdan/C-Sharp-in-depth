using System;
namespace handson.c.sharp.chapter10
{
    public class MainClass
    {

        static void Main()
        {
            SchemalessEntity parent = new SchemalessEntity { Key = "parent-key" };
            SchemalessEntity child1 = new SchemalessEntity
            {
                {
                    "name", "Jon Skeet"
                },
                {
                    "location", "Reading UK"
                }
            };
            child1.Key = "child-key";
            child1.ParentKey = parent.Key;

            SchemalessEntity child2 = new SchemalessEntity
            {
                Key = "child-key",
                ParentKey = parent.Key,
                ["name"] = "Jon Skeet",
                ["location"] = "Reading, UK"
            };


            string? name = null;

            if(name?.Equals("X") ?? false)
            {
                Console.WriteLine("The name of the variable is for sure not null and is X");
            }

            if(name?.Equals("X") ?? true)
            {
                Console.WriteLine("The name of the variable is null or is not X");
            }
        }

    }
}
