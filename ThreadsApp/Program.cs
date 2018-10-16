using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadsApp
{

    class Program
    {
        public static void ThreadMethod(ref bool stopped)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (!stopped) ;
            sw.Stop();
            Console.WriteLine($"{sw.Elapsed}");
        }

    static void Main(string[] args)
        {
            bool stopped = false;
            Thread t = new Thread(() => ThreadMethod(ref stopped))
            {
                IsBackground = true
            };
            t.Start();
            Console.ReadLine();
            stopped = true;
            Console.ReadLine();
            Console.WriteLine($"{Console.ReadLine()}");

        }
    }
}
