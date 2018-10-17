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
            private string orderNum;
            private string goodsName;
            private string client;
            public Order(string orderNum, string goodsName, string client)
            {
                this.orderNum = orderNum;
                this.goodsName = goodsName;
                this.client = client;
            }
            public string order
            {
                get
                {
                    return orderNum;
                }
                set
                {
                    orderNum = value;
                }
            }
            public string goods
            {
                get
                {
                    return goodsName;
                }
                set
                {
                    goodsName = value;
                }
            }
            public string cl
            {
                get
                {
                    return client;
                }
                set
                {
                    client = value;
                }
            }
        }
        
        public class OrderDetails
        {
            //初始化写入一部分订单
            public List<Order> Inf = new List<Order>()
            {
                new Order("1","a","A"),
                new Order("2","b","B"),
                new Order("3","c","C")
            };
           
        }
        //查询订单
        public class OrderService:OrderDetails
        {
            //添加订单
            public void addOrder(string orderNum, string goodsName, string client)
            {
                Inf.Add(new Order(orderNum, goodsName, client));
                Console.WriteLine("已添加订单" + orderNum + goodsName + client);
            }
            //删除订单
            public void deleteOrder(Order delOrder)
            {
                foreach (Order order in Inf)
                {
                    if (order.order == delOrder.order && order.goods == delOrder.goods && order.cl == delOrder.cl)
                    {
                        Inf.Remove(order);
                        Console.WriteLine("已删除订单" + delOrder.order + delOrder.goods + delOrder.cl);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("订单删除失败");
                    }
                }
            }
            //修改订单
            public void changeOrder(Order border, string orderNum, string goodsName, string client)
            {
                var tempMyOrder = new Order("", "", "");
                foreach (Order o in Inf)
                {
                    if (o.order == border.order && o.goods == border.goods && o.cl == border.cl)
                    {
                        tempMyOrder = o;
                        if (orderNum != null) tempMyOrder.order = orderNum;
                        if (goodsName != null) tempMyOrder.goods = goodsName;
                        if (client != null) tempMyOrder.cl = client;
                    }
                }
            }
            public void searchByNum(string x)
            {
                foreach(Order o in Inf)
                {
                    if (o.order == x)
                    {
                        Console.WriteLine("存在订单" + o.order + o.goods + o.cl);
                    }
                    if (o.goods == x)
                    {
                        Console.WriteLine("存在订单" + o.order + o.goods + o.cl);
                    }
                    if (o.cl == x)
                    {
                        Console.WriteLine("存在订单" + o.order + o.goods + o.cl);
                    }
                }
            }
        }
        static void Main(string[] args)
        {

        }
    }
}
