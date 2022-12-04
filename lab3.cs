using System;
using System.Threading;

namespace Lab3
{
    class Program
    {
        static EventWaitHandle wh1 = new AutoResetEvent(false),
          wh2 = new AutoResetEvent(false),
          wh3 = new AutoResetEvent(false),
          wh4 = new AutoResetEvent(false),
          wh5 = new AutoResetEvent(false);
        static private int x1, x2, x3, x4, x5, x6;
        static int A, B, C;
        static void Main(string[] args)
        {
            var T0 = new Thread(Func0);
            var T1 = new Thread(Func1);
            var T2 = new Thread(Func2);
            var T3 = new Thread(Func3);
            var T4 = new Thread(Func4);
            var T5 = new Thread(Func5);

            T0.Start();
            T1.Start();
            T2.Start();
            T3.Start();
            T4.Start();
            T5.Start();

            T0.Join();
            T1.Join();
            T2.Join();
            T3.Join();
            T4.Join();
            T5.Join();
        }

        static void Func0()
        {
            x1 = 1;
            x2 = 2;

            A = x1 * x2;
            wh1.Set();
        }

        static void Func1()
        {
            x3 = 3;
            x4 = 4;

            B = x3 * x4;
            wh2.Set();
        }

        static void Func2()
        {
            wh1.WaitOne();
            wh2.WaitOne();

            C = A + B;
            wh3.Set();
        }

        static void Func3()
        {
            x5 = 5;
            wh3.WaitOne();

            C += x5;
            wh4.Set();
        }

        static void Func4()
        {
            x6 = 6;
            wh4.WaitOne();

            C += x6;
            wh5.Set();
        }

        static void Func5()
        {
            wh5.WaitOne();
            Console.WriteLine("F = {0}", C);
        }
    }
}