using System;
using System.Collections.Generic;

namespace handson.c.sharp.chapter2
{
    public class Fibonacci
    {

        public static IEnumerable<int> Generate()
        {
            int current = 0;
            int next = 1;
            while(true)
            {
                yield return current;
                int oldCurrent = current;
                current = next;
                next = next + oldCurrent;
            }
        }

        private Fibonacci()
        {
        }
    }
}
