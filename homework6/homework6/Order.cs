using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    [Serializable]
    public class Order
    {
        private List<OrderDetail> orderDetailsList;
        public Order() { orderDetailsList = new List<OrderDetail>(); }
        public Order(uint orderId, Customer customer)
        {
            OrderId = orderId;
            Customer = customer;
            orderDetailsList = new List<OrderDetail>();
        }
        public uint OrderId { get; set; }
        public Customer Customer { get; set; }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            if (orderDetailsList
                .Where(od => od.OrderDetailId == orderDetail.OrderDetailId)
                .ToList().Count > 0)
            {
                throw new Exception($"orderDetails-{orderDetail.OrderDetailId} is already existed!");
            }
            else
            {
                orderDetailsList.Add(orderDetail);
            }
        }
        public void RemoveOrderDetail(uint orderDetailId)
        {
            for (int i = 0; i < orderDetailsList.Count; ++i)
            {
                if (orderDetailsList[i].OrderDetailId == orderDetailId)
                {
                    orderDetailsList.RemoveAt(i);
                    return;
                }
            }
            throw new Exception($"orderDetails-{orderDetailId} is not existed!");
        }
        public override string ToString()
        {
            string result = "================================================================================\n";
            result += $"orderId:{OrderId}, customer:({Customer})";
            orderDetailsList.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }
    }
}