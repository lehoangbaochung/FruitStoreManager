using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FruitStoreManager.Models
{
    class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string ImportDate { get; set; }
        public int ExpirationTime { get; set; }
        public string Description { get; set; }
    }
}
