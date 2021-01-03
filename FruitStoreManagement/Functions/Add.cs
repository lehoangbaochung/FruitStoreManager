using FruitStoreManager.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    class Add
    {
        public static string FilePath(string filename)
        {
            return Path.Combine(Environment.CurrentDirectory, filename);
        }

        public static void Customer(DataGridView dataGridView)
        {
            var oldData = File.ReadAllText(FilePath(@"Data\customer.json"));

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

                File.WriteAllText(FilePath(@"Data\customer.json"), newData);
            }
            catch (Exception)
            {
                MessageBox.Show("Input format is not valid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
