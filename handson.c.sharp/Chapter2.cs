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
            return names;
        }

        static ArrayList ArrayList_GenerateNames()
        {
            ArrayList names = new ArrayList();

            names.Add("Gamma");
            names.Add("Vlissides");
            names.Add("Johnson");
            names.Add("Helm");

            return names;
        }

        static StringCollection StringCollection_GenerateNames()
        {
            StringCollection names = new StringCollection();

            names.Add("Gamma");
            names.Add("Vlissides");
            names.Add("Johnson");
            names.Add("Helm");

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

            return names;
        }

        static void PrintNames(List<string> names)
        {
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
        }

        static void Main(string[] args) =>
            PrintNames(GenerateNames());
            //Array_PrintNames(Array_GenerateNames());
            //StringCollection_PrintNames(StringCollection_GenerateNames());
            //ArrayList_PrintNames(ArrayList_GenerateNames());
    }
}
