using FruitStoreManager.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    class CustomerManagement
    {
        public static string filePath = Path.Combine(Environment.CurrentDirectory, @"Data\customer.json");
        public static readonly BindingList<Customer> CustomerList = new BindingList<Customer>();

        public static void Display(DataGridView dataGridView)
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                var json = sr.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);

                foreach (var item in array["customer"])
                {
                    var customer = new Customer()
                    {
                        ID = item["ID"],
                        Name = item["Name"],
                        Address = item["Address"],
                        PhoneNumber = item["PhoneNumber"],
                        Email = item["Email"]
                    };

                    CustomerList.Add(customer);
                }
            }

            dataGridView.DataSource = CustomerList;
        }

        public static void Add(DataGridView dataGridView)
        {
            var oldData = File.ReadAllText(filePath);

            var customer = new Customer()
            {
                ID = dataGridView.CurrentRow.Cells[0].Value.ToString(),
                Name = dataGridView.CurrentRow.Cells[1].Value.ToString(),
                Address = dataGridView.CurrentRow.Cells[2].Value.ToString(),
                PhoneNumber = dataGridView.CurrentRow.Cells[3].Value.ToString(),
                Email = dataGridView.CurrentRow.Cells[4].Value.ToString(),
            };

            var newData = oldData.Substring(0, oldData.Length - 2) + "," + JsonConvert.SerializeObject(customer) + "]}";

            File.WriteAllText(filePath, newData);
        }
    }
}
