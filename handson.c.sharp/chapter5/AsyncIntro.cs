using System;
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

        static void Main()
        {
            AsyncIntro asyncIntro = new AsyncIntro();
            asyncIntro.DisplayWebSiteLength().Wait();
        }
    }
}
