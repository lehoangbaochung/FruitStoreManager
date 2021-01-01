using FruitStoreManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FruitStoreManager.Data
{
    class Read
    {
        public static readonly BindingList<Product> List = new BindingList<Product>();
        public static string productFilePath = Path.Combine(Environment.CurrentDirectory, @"Data\product.json");

        public static void Product(DataGridView dataGridView)
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

        public static void Add(DataGridView dataGridView)
        {
            var filePath = @"C:\Users\Asus\Downloads\product.json";
            // Read existing json data
            var oldData = File.ReadAllText(filePath);

            var product = new Product()
            {
                ID = dataGridView.RowCount + 1,
                Name = dataGridView.CurrentRow.Cells[1].Value.ToString(),
                Origin = dataGridView.CurrentRow.Cells[2].Value.ToString(),
                Quantity = (double)dataGridView.CurrentRow.Cells[3].Value,
                Price = (double)dataGridView.CurrentRow.Cells[4].Value,
                ImportDate = dataGridView.CurrentRow.Cells[5].Value.ToString(),
                ExpirationTime = (int)dataGridView.CurrentRow.Cells[6].Value,
                Description = dataGridView.CurrentRow.Cells[7].Value.ToString()
            };

            // Update json data string
            var newData = oldData.Substring(0, oldData.Length - 2) + "," + JsonConvert.SerializeObject(product) + "]}";

            File.WriteAllText(filePath, newData);
        }
    }
}
