using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{
    /// <summary>
    /// Customer the man who orders goods.
    /// </summary>
    public class Customer {
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// customer's name
        /// </summary>
        public string Name { get; set; }

        public Customer() { }
        /// <summary>
        /// Customer constructor
        /// </summary>
        /// <param name="id">customer id</param>
        /// <param name="name">customer name </param>
        public Customer(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
