using homework10;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace ordertest {
    /// <summary>
    /// OrderService:provide ordering service,
    /// like add order, remove order, query order and so on
    /// 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
    /// </summary>
    public class OrderService { 

        /// <summary>
        /// OrderService constructor
        /// </summary>
        public OrderService() {
            //orderDict = new Dictionary<string, Order>();
        }

        public List<Order> SaveOrders = new List<Order>();

        public void Add(Order order)
        {
            using (var db = new OrderDB())
            {
               db.Order.Add(order);
               SaveOrders.Add(order);
               db.SaveChanges();
            }
        }

        public void Delete(string orderId)
        {
            using (var db = new OrderDB())
            {
                var order = db.Order.Include("Details").Include("Customer").SingleOrDefault(o => o.Id == orderId);
                foreach (OrderDetail orderDetail in order.Details)
                {
                    var ods = db.OrderDetail.Include("Goods").SingleOrDefault(d => d.Id == orderDetail.Id);
                    db.Goods.Remove(ods.Goods);
                }
                db.OrderDetail.RemoveRange(order.Details);
                db.Customer.Remove(order.Customer);
                db.Order.Remove(order);

                SaveOrders.Remove(order);
                db.SaveChanges();
            }
        }

        public void Update(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Order.Attach(order);
                db.Entry(order).State = EntityState.Modified;

                db.Entry(order.Customer).State = EntityState.Modified;
                order.Details.ForEach(
                    OrderDetail => db.Entry(OrderDetail).State = EntityState.Modified);
                db.SaveChanges();
            }
        }

        public Order GetOrder(string Id)
        {
            Order order = new Order();
            foreach(Order order1 in SaveOrders)
            {
                if(order.Id.Equals(Id))
                {
                    order = order1;
                    break;
                }
            }
            return order;
        }

        public List<Order> GetAllOrders()
        {
            using (var db = new OrderDB())
            {
                    List<OrderDetail> orderDetails = db.OrderDetail.Include("Goods").ToList<OrderDetail>();
                    List<Order> orders = db.Order.Include("Details").Include("Customer").ToList<Order>();

                    foreach (Order O in orders)
                    {
                        foreach (OrderDetail ODetail in O.Details)
                        {
                            foreach (OrderDetail orderDetail in orderDetails)
                            {
                                if (ODetail.Id.Equals(orderDetail.Id))
                                {
                                    ODetail.Goods = orderDetail.Goods;
                                }
                            }
                        }
                    }
                SaveOrders = orders;
               
                return SaveOrders;   
            }
        }

        public List<Order> QueryByCustormer(String custormer)
        {
            List<Order> orderList = new List<Order>();
            foreach(Order order in SaveOrders)
            {
                if(order.Customer.Name.Equals(custormer))
                {
                    orderList.Add(order);
                }
            }
            return orderList;
        }
        public List<Order> QueryByGoods(String goods)
        {
            List<Order> orderList = new List<Order>();

            foreach(Order order in SaveOrders)
            {
                foreach(OrderDetail orderDetail in order.Details)
                {
                    if(orderDetail.Goods.Name.Equals(goods))
                    {
                        orderList.Add(order);
                    }
                }
            }
            return orderList;
        }

        public void ExportXML(List<Order>orders)//输出为xml文件
        {
            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
                xmlSerializer.Serialize(stringWriter, orders);
                FileStream fs = new FileStream("../../orders.xml", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write(stringWriter.ToString());
                sw.Close();
                fs.Close();
            }

        }

        public void ExportHTML(List<Order> orders)
        {
            ExportXML(orders);
            //XPathDocument myXPathDoc = new XPathDocument();
            string xmlContent = File.ReadAllText("../../orders.xml");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlContent);


            XslCompiledTransform myXslTrans = new XslCompiledTransform();
            myXslTrans.Load("../../orders.xslt");
            XmlTextWriter myWriter = new XmlTextWriter("../../result.html", null);
            myXslTrans.Transform(xmlDoc, null, myWriter);
            myWriter.Flush();
            myWriter.Close();

        }
        /*other edit function with write in the future.*/
    }
}
