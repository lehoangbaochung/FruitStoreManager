using FruitStoreManager.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace FruitStoreManager.Staff
{
    class CustomerManagement
    {
        public static string productFilePath = Path.Combine(Environment.CurrentDirectory, @"Data\product.json");
        public static readonly BindingList<Customer> List = new BindingList<Customer>();

        public static void Display(DataGridView dataGridView)
        {
            using (StreamReader sr = File.OpenText(productFilePath))
            {
                var json = sr.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);

                foreach (var item in array["Product"])
                {
                    var customer = new Customer()
                    {
                        ID = (int)item["ID"],
                        Name = item["Name"],
                        Address = item["Address"],
                        PhoneNumber = (int)item["PhoneNumber"],
                        Email = item["Email"]
                    };

                    List.Add(customer);
                }

                dataGridView.DataSource = List;
            }
        }
    }
}
