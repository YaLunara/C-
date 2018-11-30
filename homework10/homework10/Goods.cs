using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {
    /// <summary>
    /// Goods class:the message of goods
    /// </summary>
    public class Goods {
        public Goods() { }
        public Goods(string id, string name, double value) {
            Id = id;
            Name = name;
            Price = value;
        }

        [Key]
        public string Id { get; set; }

        /// <summary>
        /// property : goods name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// property : goods value
        /// </summary>
        public double Price {
            get;
            set;
            
        }
    }
}
