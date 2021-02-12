using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
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

        static Task<int> ComputeLengthAsync(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            return ComputeLengthAsyncImpl(text);
        }

        static async Task<int> ComputeLengthAsyncImpl(string text)
        {

            await Task.Delay(500);
            return text.Length;
        }

        Func<int, Task<int>> function = async x =>
        {
            Console.WriteLine("Starting... x={0}", x);
            await Task.Delay(x * 1000);
            Console.WriteLine("Finished... x={0}", x);
            return x * 2;
        };



        static async Task PrintAndWait(TimeSpan delay)
        {
            Console.WriteLine("Before first delay");
            await Task.Delay(delay);
            Console.WriteLine("Between delays");
            await Task.Delay(delay);
            Console.WriteLine("After second delay");
        }


        static void ShowInfo(
            [CallerFilePath] string fileName = null,
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = null)
        {
            Console.WriteLine("{0}:{1} - {2}", fileName, lineNumber, memberName);
        }

        //static async Task Main()
        //{

        //    AsyncIntro asyncIntro = new AsyncIntro();
        //    asyncIntro.DisplayWebSiteLength().Wait();


        //    Task task = DemoCompletedAsync();
        //    Console.WriteLine("method returned");
        //    task.Wait();
        //    Console.WriteLine("Task completed");

        //    //Task<int> computedLengthTask = ComputeLengthAsync(null);
        //    //Console.WriteLine("fetched the task");
        //    //int length = await computedLengthTask; // here it will throw the ArgumentNotNullException
        //    //Console.WriteLine("Length: {0}", length);

        //    Task<int> first = asyncIntro.function(5);
        //    Task<int> second = asyncIntro.function(3);

        //    int firstResult = await first;
        //    int secondResult = await second;

        //    Console.WriteLine("First result: {0}", firstResult);
        //    Console.WriteLine("Second result: {0}", secondResult);

        //    //List<string> values = new List<string> { "x", "y", "z", "t" };
        //    //List<Action> actions = new List<Action>();
        //    //for (int i = 0; i < values.Count; i++)
        //    //{
        //    //    //actions.Add(() => Console.WriteLine("Executed action {0}", values[i])); 
        //    //}

        //    //for (int i = 0; i < actions.Count; i++)
        //    //{
        //    //    actions[i]();
        //    //}

        //    // the above code throws ArgumentOutOfRangeException

        //    ShowInfo();
        //    ShowInfo("~/someFile.txt", 20);

        //    var collectionInitializer = new Dictionary<string, int>
        //    {
        //        {"A", 20 },
        //        {"B", 30 },
        //        //{"B", 40 } // here it will throw an exception 'cause the 'B' key already exist
        //    };

        //    var objectInitializer = new Dictionary<string, int>
        //    {
        //        ["A"] = 20,
        //        ["B"] = 30,
        //        ["B"] = 40
        //    };
        //}
    }
}
