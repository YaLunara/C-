using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array;
            Console.WriteLine("请输入元素个数：");
            int length = Convert.ToInt32(Console.ReadLine());
            array = new int[length];
            for(int i = 0; i < length; i++)//输入数组元素
            {
                Console.Write("请输入第{0}个数组的值：", (i+1));
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            //数组最大值和最小值
            int max = array[0];
            int min = array[0];
            for(int i = 1; i < length; i++)
            {
                if (array[i] > max)
                    max = array[i];
                if (array[i] < min)
                    min = array[i];
            }
            Console.WriteLine("数组元素的最大值为：" + max);
            Console.WriteLine("数组元素的最小值为：" + min);
            //数组元素的和
            int sum = 0;
            for(int i = 0; i < length; i++)
            {
                sum += array[i];
            }
            Console.WriteLine("数组元素的和为：" + sum);
            //数组元素平均值
            double average = 1.0*sum / length;
            Console.WriteLine("数组元素的平均值为：" + average);
        }
    }
}
