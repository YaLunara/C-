using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = ""; string s2 = "";
            double d1 = 0; double d2 = 0;
            Console.Write("Please input a double:");
            s1 = Console.ReadLine();
            d1 = Double.Parse(s1);
            Console.Write("Please input another double:");
            s2 = Console.ReadLine();
            d2 = Double.Parse(s2);
            Console.WriteLine("Multiplicative value of two numbers is:" + (d1 * d2));
        }
    }
}
