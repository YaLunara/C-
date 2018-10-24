using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace homework6
{
    [Serializable]
    public class OrderService
    {
        private Dictionary<uint, Order> orderDict;
        public OrderService()
        {
            orderDict = new Dictionary<uint, Order>();
        }
        public List<Order> Orders
        {
            get { return orderDict.Values.ToList(); }
        }
        public void AddOrder(Order order)
        {
            if (orderDict.ContainsKey(order.OrderId))
                throw new Exception($"order-{order.OrderId} is already existed!");
            orderDict[order.OrderId] = order;
        }
        public void RemoveOrder(uint orderId)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict.Remove(orderId);
            }
        }
        public List<Order> QueryOrderById(uint orderId)
        {
            return orderDict.Values.ToList<Order>()
                .Where(order => order.OrderId == orderId)
                .ToList();      // LINQ Query
        }
        //public List<Order> QueryOrdersByGoodsName(string goodsName)
        //{
        //    List<Order> result = new List<Order>();
        //    orderDict.Values.ToList().ForEach(order => {    // using Lamada
        //        List<OrderDetail> orderDetailsList = order.OrderDetail
        //            .Where(orderDetail => orderDetail.Goods.GoodsName == goodsName)
        //            .ToList();      // using LINQ
        //        if (orderDetailsList.Count > 0)
        //            result.Add(order);
        //    });
        //    return result;
        //}
        public List<Order> QueryOrdersByCustomerName(string customerName)
        {
            return orderDict.Values.ToList()
                .Where(order => order.Customer.CustomerName == customerName)
                .ToList();  // LINQ Query
        }
        public void UpdateOrderCustomer(uint orderId, Customer newCustomer)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict[orderId].Customer = newCustomer;
            }
            else
            {
                throw new Exception("Order is not existed!");
            }
        }
        public void Export()
        {
            //XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("List.xml", FileMode.Create))
            {
                bf.Serialize(fs, Orders);
            }
        }
        public List<Order> Import()
        {
            //XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            BinaryFormatter bf = new BinaryFormatter();
            List<Order> result = new List<Order>();
            try
            {
                using (FileStream fs = new FileStream("List.xml", FileMode.Open))
                {
                    List<Order> temp = (List<Order>)bf.Deserialize(fs);
                    temp.ForEach(order => {
                        if (!orderDict.Keys.Contains(order.OrderId))
                        {
                            orderDict[order.OrderId] = order;
                            result.Add(order);
                        }
                    });
                }
            }
            catch (FileNotFoundException)
            {
                throw new Exception("File not found!");
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Xml file code error!");
            }
            return result;
        }
    }
}
