using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FruitStoreManager.Models
{
    class Product
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string ImportDate { get; set; }
        public string ExpirationTime { get; set; }
        public string Description { get; set; }
    }
}
