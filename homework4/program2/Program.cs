using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program2
{
    class Program
    {
        public class Order
        {
            public struct myOrder
            {
                public string orderNum { get; set; }
                public string goodsName { get; set; }
                public string client { get; set; }
                public myOrder(string orderNum, string goodsName, string client)
                {
                    this.orderNum = orderNum;
                    this.goodsName = goodsName;
                    this.client = client;
                }
            }
        }
        
        public class OrderDetails : Order
        {
            //初始化写入一部分订单
            public List<myOrder> Inf = new List<myOrder>()
            {
                new myOrder("1","a","A"),
                new myOrder("2","b","B"),
                new myOrder("3","c","C")
            };
            //添加订单
            public void addOrder(string orderNum, string goodsName, string client)
            {
                Inf.Add(new myOrder(orderNum, goodsName, client));
                Console.WriteLine("已添加订单" + orderNum + goodsName + client);
            }
            //删除订单
            public void deleteOrder(myOrder delOrder)
            {
                foreach (myOrder order in Inf)
                {
                    if (order.orderNum == delOrder.orderNum && order.goodsName == delOrder.goodsName && order.client == delOrder.client)
                    {
                        Inf.Remove(order);
                        Console.WriteLine("已删除订单" + delOrder.orderNum + delOrder.goodsName + delOrder.client);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("订单删除失败");
                    }
                }
            }
            //修改订单
            public void changeOrder(myOrder border,string orderNum,string goodsName,string client)
            {
                var tempMyOrder = new myOrder("", "", "");
                foreach (myOrder o in Inf)
                {
                    if(o.orderNum==border.orderNum&&o.goodsName==border.goodsName&&o.client==border.client)
                    {
                        tempMyOrder = o;
                        if (orderNum != null) tempMyOrder.orderNum = orderNum;
                        if (goodsName != null) tempMyOrder.goodsName = goodsName;
                        if (client != null) tempMyOrder.client = client;
                    }
                }
            }
        }
        //查询订单
        public class OrderService:OrderDetails
        {
            public void searchByNum(string x)
            {
                foreach(myOrder o in Inf)
                {
                    if (o.orderNum == x)
                    {
                        Console.WriteLine("存在订单" + o.orderNum + o.goodsName + o.client);
                    }
                    if (o.goodsName == x)
                    {
                        Console.WriteLine("存在订单" + o.orderNum + o.goodsName + o.client);
                    }
                    if (o.client == x)
                    {
                        Console.WriteLine("存在订单" + o.orderNum + o.goodsName + o.client);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
