using FruitStoreManager.Events;
using FruitStoreManager.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    class Add
    {
        public static void Bill(DataGridView dataGridView)
        {
            var oldData = File.ReadAllText(Execute.GetFilePath("bill")).Trim();

            var bill = new Bill()
            {
                ID = Display.BillList.Count + 1,
                EmployeeID = Check.AccountInfo.Username,
                CustomerName = dataGridView.CurrentRow.Cells["CustomerName"].Value,
                PaymentMethod = dataGridView.CurrentRow.Cells["PaymentMethod"].Value,
                Time = DateTime.Now.ToString("dd/mm/yy hh:mm:ss")
            };

            int total = 0;
            foreach (var product in Item.DetailList) total += int.Parse(product.Sum.ToString());
            bill.Total = total;

            var newData = oldData.Substring(0, oldData.Length - 2) + "," + JsonConvert.SerializeObject(bill) + "]}";

            File.WriteAllText(Execute.GetFilePath("bill"), newData);
        }

        public static void Product(DataGridView dataGridView)
        {
            var oldData = File.ReadAllText(Execute.GetFilePath("product")).Trim();

            var product = new Product()
            {
                ID = dataGridView.RowCount.ToString(),
                Name = dataGridView.CurrentRow.Cells[1].Value,
                Origin = dataGridView.CurrentRow.Cells[2].Value,
                Quantity = dataGridView.CurrentRow.Cells[3].Value,
                Price = dataGridView.CurrentRow.Cells[4].Value,
                ImportDate = dataGridView.CurrentRow.Cells[5].Value,
                ExpirationTime = dataGridView.CurrentRow.Cells[6].Value,
                Description = dataGridView.CurrentRow.Cells[7].Value
            };

            var newData = oldData.Substring(0, oldData.Length - 2) + "," + JsonConvert.SerializeObject(product) + "]}";

            File.WriteAllText(Execute.GetFilePath("product"), newData);
        }

        public static void Customer(DataGridView dataGridView)
        {
            var oldData = File.ReadAllText(Execute.GetFilePath("customer")).Trim();

            var customer = new Customer()
            {
                ID = dataGridView.RowCount.ToString(),
                Name = dataGridView.CurrentRow.Cells[1].Value,
                Address = dataGridView.CurrentRow.Cells[2].Value,
                PhoneNumber = dataGridView.CurrentRow.Cells[3].Value,
                Email = dataGridView.CurrentRow.Cells[4].Value
            };

            var newData = oldData.Substring(0, oldData.Length - 2) + "," + JsonConvert.SerializeObject(customer) + "]}";

            File.WriteAllText(Execute.GetFilePath("customer"), newData);
        }
    }
}
