using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using handson.c.sharp.chapter2;

namespace handson.c.sharp.Chapter2
{
    class ValidatingList<T>
    {
        private readonly List<T> items = new List<T>();
    }

    class Chapter2
    {
        static string[] Array_GenerateNames()
        {
            string[] names = new string[4]; 
            names[0] = "Gamma"; 
            names[1] = "Vlissides";
            names[2] = "Johnson";
            names[3] = "Helm";

            //names[5] = 1; // compile time error, but anyhow, it will fail due to the fact that the string array has fixed size
            return names;
        }

        static ArrayList ArrayList_GenerateNames()
        {
            ArrayList names = new ArrayList();

            names.Add("Gamma");
            names.Add("Vlissides");
            names.Add("Johnson");
            names.Add("Helm");
             
            //names.Add(1); // this does not fail at compile time, but will fail at runtime

            return names;
        }

        static StringCollection StringCollection_GenerateNames()
        {
            StringCollection names = new StringCollection();

            names.Add("Gamma");
            names.Add("Vlissides");
            names.Add("Johnson");
            names.Add("Helm");

            //names.Add(1); // compile time error

            return names;
        }

        static void ArrayList_PrintNames(ArrayList names)
        {
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
        }

        static void Array_PrintNames(string[] names)
        {
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
        }

        static void StringCollection_PrintNames(StringCollection names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }

        //Generics save the day

        static List<string> GenerateNames()
        {
            List<string> names = new List<string>();

            names.Add("Gamma");
            names.Add("Vlissides");
            names.Add("Johnson");
            names.Add("Helm");

            //names.Add(1); // compile time error
            return names;
        }

        static List<int> GenerateNumbers()
        {
            List<int> numbers = new List<int>();

            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);

            return numbers;
        }

        static void PrintList<T>(List<T> input)
        {
            foreach(T t in input)
            {
                Console.WriteLine(t);
            }
        }

        static void PrintNames(List<string> names)
        {
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
        }

        static List<T> CopyAtMost<T>(List<T> input, int maxElements)
        {
            int actualCount = Math.Min(input.Count, maxElements);
            List<T> ret = new List<T>(actualCount);

            for (int i = 0; i < actualCount; i++)
            {
                ret.Add(input[i]);
            }

            return ret;
        }

        static void PrintItems<T>(List<T> input) where T : IFormattable
        {
            CultureInfo culture = CultureInfo.InvariantCulture;
            foreach(T item in input)
            {
                Console.WriteLine(item.ToString(null, culture));
            }
        }

        static void PrintType<T>()
        {
            Console.WriteLine($"typeof(T) = {typeof(T)}");
            Console.WriteLine($"typeof(List<T>) = {typeof(List<T>)}");
        }

        static void DisplayMaxPrice(Nullable<decimal> maxPrice)
        {
            if(maxPrice.HasValue)
            {
                Console.WriteLine($"Maximum price: {maxPrice.Value}");
            }
            else
            {
                Console.WriteLine("No maximum price set.");
            }
        }

        static IEnumerable<int> CreateSimpleIterator()
        {
            yield return 10;
            for(int i =0;i<3;i++)
            {
                yield return i;
            }
            yield return 20;
        }


        static void Main(string[] args)
        {
            //List<int> numbers = GenerateNumbers();
            //List<int> result = CopyAtMost(numbers, 2);
            //PrintList(result);

            //Console.WriteLine($"Default value of an empty list: {default(List<int>)}");
            //Console.WriteLine(typeof(List<int>));
            //Console.WriteLine(result.GetType());

            //PrintType<string>();
            //PrintType<String>();
            //PrintType<int>();

            //Console.WriteLine($"typeof(List<>) {typeof(List<>)}");
            //Console.WriteLine($"typeof(Dictionary<,>) {typeof(Dictionary<,>)}");

            //PrintNames(GenerateNames());
            //Array_PrintNames(Array_GenerateNames());
            //StringCollection_PrintNames(StringCollection_GenerateNames());
            //ArrayList_PrintNames(ArrayList_GenerateNames());

            GenericCounter<string>.Increment();
            GenericCounter<string>.Increment();
            GenericCounter<string>.Display();

            GenericCounter<int>.Display();
            GenericCounter<int>.Increment();
            GenericCounter<int>.Display();

            Nullable<int> nullableInt = new Nullable<int>();

            Console.WriteLine(nullableInt.HasValue);

            DisplayMaxPrice(new Nullable<decimal>());

            Console.WriteLine($"nullableInt.GetValueOrDefault(): {nullableInt.GetValueOrDefault()}");
            Console.WriteLine($"nullableInt.GetValueOrDefault(100): {nullableInt.GetValueOrDefault(100)}");

            Nullable<int> noValue = new Nullable<int>();
            object noValueBoxed = noValue;
            Console.WriteLine(noValueBoxed == null);
            //Console.WriteLine(noValue.GetType());


            Nullable<int> someValue = new Nullable<int>(5);
            object someValueBoxed = someValue;
            Console.WriteLine(someValueBoxed.GetType());

            int? x = 0;
            int y = 1;

            int? z = x + y;
            
            Console.WriteLine($"the value of z is {z}");

            x = null;
            z = x + y;

            Console.WriteLine($"the value of z is {z}");

            static void PrintValueAsInt32(object o)
            {
                int? nullable = o as int?;
                Console.WriteLine(nullable.HasValue ?
                                  nullable.Value.ToString() : "null");
            }
            
            PrintValueAsInt32(5); 
            PrintValueAsInt32("some string");

            foreach(int value in CreateSimpleIterator())
            {
                Console.WriteLine($"yield value: {value}");
            }
        }
    }
}
