using System;
using System.Threading;
namespace Lab2
{
    class Program
    {
        static int x = 3, y = 5, z = 4;
        static Thread T1, T2, T3, T4, T5;
        static void Main(string[] args)
        {
            Console.WriteLine("x = {0}; y = {1}; z = {2}", x, y, z);

            T1 = new Thread(() => { y += 2; });
            T1.Start();

            T2 = new Thread(() => {
                T1.Join();
                x *= 5;
            });
            T2.Start();

            T3 = new Thread(() => {
                T1.Join();
                y *= 2;
            });
            T3.Start();

            T4 = new Thread(() => {
                T1.Join();
                z -= 3;
            });
            T4.Start();

            T5 = new Thread(() => {
                T2.Join();
                T3.Join();
                T4.Join();
                x = x + y + z;
            });
            T5.Start();
            T5.Join();

            Console.WriteLine("x = {0}; y = {1}; z = {2}", x, y, z);
        }
    }
}
