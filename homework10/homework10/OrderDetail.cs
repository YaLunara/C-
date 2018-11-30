using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {

    /// <summary>
    /// OrderDetail class : a entry of an order object
    /// to record the goods and its quantity
    /// </summary>
    public class OrderDetail {
        /// <summary>
        /// OrderDetail constructor
        /// </summary>
        /// <param name="id">orderDetail's id</param>
        /// <param name="goods">orderDetail's goods</param>
        /// <param name="quantity">goods quantity</param>
        
        public OrderDetail() { }
        public OrderDetail(string id, Goods goods, uint quantity) {
            this.Id = id;
            this.Goods = goods;
            this.Quantity = quantity;
        }

        [Key]
        public string Id { get; set; }

        /// <summary>
        /// orderDetail's goods
        /// </summary>
        public Goods Goods { get; set; }

        /// <summary>
        /// goods quantity
        /// </summary>
        public uint Quantity { get; set; }


        public override int GetHashCode()
        {
            var hashCode = 1522631281;
            hashCode = hashCode * -1521134295 + Goods.Name.GetHashCode();
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }


    }
}
