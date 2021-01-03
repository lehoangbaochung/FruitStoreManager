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
        public static readonly BindingList<Customer> BindingList = new BindingList<Customer>();

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

                    BindingList.Add(customer);
                }
            }

            dataGridView.DataSource = BindingList;
        }

        public static void Add(DataGridView dataGridView)
        {
            var oldData = File.ReadAllText(filePath);

            try
            {
                var customer = new Customer()
                {
                    ID = dataGridView.RowCount.ToString(),
                    Name = Check.Null(dataGridView.CurrentRow.Cells[1].Value?.ToString()),
                    Address = Check.Null(dataGridView.CurrentRow.Cells[2].Value?.ToString()),
                    PhoneNumber = Check.Integer(dataGridView.CurrentRow.Cells[3].Value?.ToString()),
                    Email = Check.Email(dataGridView.CurrentRow.Cells[4].Value?.ToString()),
                };

                if (customer == null) return;

                var newData = oldData.Substring(0, oldData.Length - 2) + "," + JsonConvert.SerializeObject(customer) + "]}";

                File.WriteAllText(filePath, newData);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Input format is not valid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Input format is not valid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
