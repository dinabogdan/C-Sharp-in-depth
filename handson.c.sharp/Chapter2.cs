using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace handson.c.sharp.Chapter2
{
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

        static void Main(string[] args)
        {
            List<int> numbers = GenerateNumbers();

            List<int> result = CopyAtMost(numbers, 2);

            PrintList(result);

            //PrintNames(GenerateNames());
            //Array_PrintNames(Array_GenerateNames());
            //StringCollection_PrintNames(StringCollection_GenerateNames());
            //ArrayList_PrintNames(ArrayList_GenerateNames());
        }
    }
}
