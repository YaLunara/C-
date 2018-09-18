using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("2--100以内的素数：");
            for(int i = 2; i < 101; i++)//循环2--100的整数
            {
                if (i == 2)
                {
                    Console.Write(i + " ");
                }
                else
                {
                    int j = 2;
                    for(; j < i; j++)
                    {
                        if (i % j == 0)
                            break;
                    }
                    if (j == i)
                        Console.Write(i + " ");
                }
            }
        }
    }
}
