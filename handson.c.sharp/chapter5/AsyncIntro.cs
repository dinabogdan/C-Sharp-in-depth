﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace handson.c.sharp.chapter5
{
    public class AsyncIntro
    {
        private static readonly HttpClient client = new HttpClient();

        public AsyncIntro()
        {
        }

        async Task DisplayWebSiteLength()
        {
            Console.WriteLine("Fetching ...");
            string text = await client.GetStringAsync("http://csharpindepth.com");
            Console.WriteLine(text);
        }

        static async Task DemoCompletedAsync()
        {
            Console.WriteLine("Before first await");
            await Task.FromResult(10);
            Console.WriteLine("Between awaits");
            await Task.Delay(1000);
            Console.WriteLine("After second await");
        }

        static async Task<int> ComputeLengthAsync(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            await Task.Delay(500);
            return text.Length;
        }

        static async Task Main()
        {
            AsyncIntro asyncIntro = new AsyncIntro();
            asyncIntro.DisplayWebSiteLength().Wait();


            Task task = DemoCompletedAsync();
            Console.WriteLine("method returned");
            task.Wait();
            Console.WriteLine("Task completed");

            Task<int> computedLengthTask = ComputeLengthAsync(null);
            Console.WriteLine("fetched the task");
            int length = await computedLengthTask;
            Console.WriteLine("Length: {0}", length);
        }
    }
}
