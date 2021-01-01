using FruitStoreManager.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace FruitStoreManager.Staff
{
    class ProductManagement
    {
        public static string productFilePath = Path.Combine(Environment.CurrentDirectory, @"Data\product.json");
        public static readonly BindingList<Product> List = new BindingList<Product>();

        public static void Display(DataGridView dataGridView)
        {
            using (StreamReader sr = File.OpenText(productFilePath))
            {
                var json = sr.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);

                foreach (var item in array["Product"])
                {
                    var product = new Product()
                    {
                        ID = (int)item["ID"],
                        Name = item["Name"],
                        Origin = item["Origin"],
                        Quantity = (double)item["Quantity"],
                        Price = (double)item["Price"],
                        ImportDate = item["ImportDate"],
                        ExpirationTime = (int)item["ExpirationTime"],
                        Description = item["Description"]
                    };

                    List.Add(product);
                }

                dataGridView.DataSource = List;
            }
        }
    }
}
