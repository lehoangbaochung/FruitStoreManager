using FruitStoreManager.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    class ProductManagement
    {
        public static string filePath = Path.Combine(Environment.CurrentDirectory, @"Data\product.json");
        public static readonly BindingList<Product> BindingList = new BindingList<Product>();

        public static void Display(DataGridView dataGridView)
        {
            using StreamReader sr = File.OpenText(filePath);
            var json = sr.ReadToEnd();
            dynamic array = JsonConvert.DeserializeObject(json);

            foreach (var item in array["product"])
            {
                var product = new Product()
                {
                    ID = item["ID"],
                    Name = item["Name"],
                    Origin = item["Origin"],
                    Quantity = item["Quantity"],
                    Price = item["Price"],
                    ImportDate = item["ImportDate"],
                    ExpirationTime = item["ExpirationTime"],
                    Description = item["Description"]
                };

                BindingList.Add(product);
            }

            dataGridView.DataSource = BindingList;
        }

        public static void Add(DataGridView dataGridView)
        {
            var oldData = File.ReadAllText(filePath);

            var product = new Product()
            {
                ID = dataGridView.CurrentRow.Cells[0].Value.ToString(),
                Name = dataGridView.CurrentRow.Cells[1].Value.ToString(),
                Origin = dataGridView.CurrentRow.Cells[2].Value.ToString(),
                Quantity = dataGridView.CurrentRow.Cells[3].Value.ToString(),
                Price = dataGridView.CurrentRow.Cells[4].Value.ToString(),
                ImportDate = dataGridView.CurrentRow.Cells[5].Value.ToString(),
                ExpirationTime = dataGridView.CurrentRow.Cells[6].Value.ToString(),
                Description = dataGridView.CurrentRow.Cells[7].Value.ToString()
            };

            var newData = oldData.Substring(0, oldData.Length - 2) + "," + JsonConvert.SerializeObject(product) + "]}";

            File.WriteAllText(filePath, newData);
        }
    }
}
