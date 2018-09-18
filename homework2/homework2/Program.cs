using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个数：");
            string s = Console.ReadLine();
            int n = int.Parse(s);
            Console.WriteLine("该数的素数因子为：");
            int i = 2;
            for (; i <= n; i++)
            {
                while (i != n)
                {
                    if (n % i == 0)
                    {
                        Console.Write(i + " ");
                        do
                        {
                            n /= i;
                        }
                        while (n % i == 0);
                    }
                    else
                        break;
                }
            }
            if (i != n)
                Console.Write(n);
        }
    }
}
