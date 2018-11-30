using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {

    /// <summary>
    /// Order class : all orderDetails
    /// to record each goods and its quantity in this ordering
    /// </summary>
    public class Order {
        [Key]
        public string Id { get; set; }

        private List<OrderDetail> details=new List<OrderDetail>();

        public Order() { }
        /// <summary>
        /// Order constructor
        /// </summary>
        /// <param name="orderId">order id</param>
        /// <param name="customer">who orders goods</param>
        public Order(string orderId, Customer customer) {
            DateTime dt = DateTime.Now;
            Id = orderId;
            Customer = customer;
        }

        /// <summary>
        /// the man who orders goods
        /// </summary>
        public Customer Customer { get; set; }


        public double Amount
        {
            get;
            set;
        } 
            
        
        public List<OrderDetail> Details {
            set { }
            get
            {
                return this.details;
            }
           
        }

        /// <summary>
        /// add new orderDetail to order
        /// </summary>
        /// <param name="orderDetail">the new orderDetail which will be added</param>
        public void AddDetails(OrderDetail orderDetail) {
            if (this.Details.Contains(orderDetail))  {
                throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
            }
            details.Add(orderDetail);
        }

        /// <summary>
        /// remove orderDetail by orderDetailId from order
        /// </summary>
        /// <param name="orderDetailId">id of the orderDetail which will be removed</param>
        public void RemoveDetails(string orderDetailId) {
            details.RemoveAll(d =>d.Id==orderDetailId);
        }
    }
}
