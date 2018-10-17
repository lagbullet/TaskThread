using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadsApp
{

    class Program
    {
        public static void ThreadMethod(ref bool stopped, string threadname)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (!stopped)
            {
                Console.WriteLine($"{threadname} is running...");
                Thread.Sleep(500);
            }
            sw.Stop();
            Console.WriteLine($"{threadname} is done in {sw.Elapsed} seconds");
        }

    static void Main(string[] args)
        {
            bool t1 = false;
            Thread T1 = new Thread(() => ThreadMethod(ref t1,"Thread 1"))
            {
                IsBackground = true
            };
            T1.Start();
            bool t2 = false;
            Thread T2 = new Thread(() => ThreadMethod(ref t2, "Thread 2"));
            T2.Start();
            Console.ReadLine();
            t1 = true;
            Console.ReadLine();
            t2 = true;
            Console.ReadLine();
            T2.Join();
        }
    }
}
