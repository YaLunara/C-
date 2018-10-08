using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace homework4
{
    class Program
    {
        //声明参数类型
        public class ClockEventArgs : EventArgs
        {
            public DateTime realTime;
            public DateTime clockTime;
        }
        //声明委托类型
        public delegate void ClockEventHandler(object sender, ClockEventArgs e);
        //定义事件源
        public class Clock
        {
            //声明事件
            public event ClockEventHandler SetClock;
 
            public void DoSetClock(ref DateTime tempTime)
            {
                ClockEventArgs args = new ClockEventArgs();
                args.clockTime = tempTime;
                args.realTime = DateTime.Now;
                if (args.clockTime < args.realTime)
                    throw new ArgumentOutOfRangeException("error setTime!");
                while (args.clockTime > args.realTime)
                {
                    //时间逐渐接近，用延迟一会来代替
                    System.Threading.Thread.Sleep(500);
                    if (args.clockTime != args.realTime)
                    {
                        args.realTime = DateTime.Now;
                        SetClock(this, args);
                    }
                }
                Console.WriteLine("闹钟时间到！");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("设定时间，格式按照" + DateTime.Now);
            string s = Console.ReadLine();
            DateTime setClock = DateTime.Parse(s);

            var clock = new Clock();
            //注册事件
            clock.SetClock += Clock_SetClock;
            clock.DoSetClock(ref setClock);
        }

        static void Clock_SetClock(object sender, ClockEventArgs e)
        {
            Console.WriteLine("闹钟时间未到......");
        }
    }
}
