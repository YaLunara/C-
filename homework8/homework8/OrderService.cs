using System;
using System.Collections.Generic;
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

        private Dictionary<uint, Order> orderDict;
        /// <summary>
        /// OrderService constructor
        /// </summary>
        public OrderService() {
            orderDict = new Dictionary<uint, Order>();
        }

        /// <summary>
        /// add new order
        /// </summary>
        /// <param name="order">the order will be added</param>
        public void AddOrder(Order order) {
            uint.TryParse(order.Id.Remove(0, order.Id.Length - 3), out uint a);
            uint id = Convert.ToUInt16(order.Id.Remove(0, order.Id.Length - 3));
            if (orderDict.ContainsKey(id))
                throw new Exception($"order-{order.Id} is already existed!");
            orderDict[id] = order;
        }

        /// <summary>
        /// cancel order
        /// </summary>
        /// <param name="orderId">id of the order which will be canceled</param> 
        public void RemoveOrder(uint orderId) {
              orderDict.Remove(orderId);
        }

        /// <summary>
        /// query all orders
        /// </summary>
        /// <returns>List<Order>:all the orders</returns> 
        public List<Order> QueryAllOrders() {
            return orderDict.Values.ToList();
        }

        /// <summary>
        /// query by orderId
        /// </summary>
        /// <param name="orderId">id of the order to find</param>
        /// <returns>List<Order></returns> 
        public Order GetById(uint orderId) {
            return orderDict[orderId];
        }

        /// <summary>
        /// query by goodsName
        /// </summary>
        /// <param name="goodsName">the name of goods in order's orderDetail</param>
        /// <returns></returns> 
        public List<Order> QueryByGoodsName(string goodsName) {
            var query = orderDict.Values.Where(order =>
                    order.Details.Where(d => d.Goods.Name == goodsName)
                    .Count() > 0
                );
            return query.ToList();
   
        }

        /// <summary>
        /// query by customerName
        /// </summary>
        /// <param name="customerName">customer name</param>
        /// <returns></returns> 
        public List<Order> QueryByCustomerName(string customerName) {
            var query=orderDict.Values
                .Where(order => order.Customer.Name == customerName);
            return query.ToList();
        }

        public List<Order> QueryByPrice(double price)
        {
            //var query = orderDict.Values
            //    .Where(order => order.Amount> price);
            //return query.ToList();
            return null;
        }


        /// <summary>
        /// edit order's customer
        /// </summary>
        /// <param name="orderId"> id of the order whoes customer will be update</param>
        /// <param name="newCustomer">the new customer of the order which will be update</param> 
        public void UpdateCustomer(uint orderId, Customer newCustomer) {
            if (orderDict.ContainsKey(orderId)) {
                orderDict[orderId].Customer = newCustomer;
            } else {
                throw new Exception($"order-{orderId} is not existed!");
            }
        }
        public List<Order> Orders
        {
            get { return orderDict.Values.ToList(); }
        }
        public void ExportXML()//输出为xml文件
        {
            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
                xmlSerializer.Serialize(stringWriter, Orders);
                FileStream fs = new FileStream("orders.xml", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write(stringWriter.ToString());
                sw.Close();
                fs.Close();
            }

        }

        public void ExportHTML()
        {
            ExportXML();
            //XPathDocument myXPathDoc = new XPathDocument();
            string xmlContent = File.ReadAllText("orders.xml");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlContent);


            XslCompiledTransform myXslTrans = new XslCompiledTransform();
            myXslTrans.Load("orders.xslt");
            XmlTextWriter myWriter = new XmlTextWriter("result.html", null);
            myXslTrans.Transform(xmlDoc, null, myWriter);
            myWriter.Flush();
            myWriter.Close();

        }
        /*other edit function with write in the future.*/
    }
}
