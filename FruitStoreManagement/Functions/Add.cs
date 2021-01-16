using FruitStoreManager.Events;
using FruitStoreManager.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    class Add
    {
        public static void Account(DataGridView dataGridView)
        {
            var oldData = File.ReadAllText(Execute.GetFilePath("account")).Trim();

            var account = new Account()
            {
                ID = dataGridView.CurrentRow.Cells["ID"].Value,
                Password = dataGridView.CurrentRow.Cells["Password"].Value,
                Permission = dataGridView.CurrentRow.Cells["Permission"].Value
            };

            var newData = oldData.Remove(oldData.Length - 2) + "," + JsonConvert.SerializeObject(account) + "]}";

            File.WriteAllText(Execute.GetFilePath("account"), newData);
        }

        public static void BillDetail() // thêm các item trong giỏ vào file billdetail
        {
            var oldData = File.ReadAllText(Execute.GetFilePath("billdetail")).Trim();

            string newItem = null;

            foreach (var item in List.Cart) newItem += JsonConvert.SerializeObject(item) + ",";

            var newData = oldData.Remove(oldData.Length - 2) + "," + newItem.Substring(0, newItem.Length - 1) + "]}";

            File.WriteAllText(Execute.GetFilePath("billdetail"), newData);
        }

        public static void Bill(DataGridView dataGridView)
        {
            BillDetail();

            var oldData = File.ReadAllText(Execute.GetFilePath("bill")).Trim();

            var bill = new Bill()
            {
                ID = BindingList.Bill.Count,
                EmployeeID = Check.AccountInfo.ID,
                CustomerName = dataGridView.CurrentRow.Cells["CustomerName"].Value,
                PaymentMethod = dataGridView.CurrentRow.Cells["PaymentMethod"].Value,
                Time = DateTime.Now.ToString("dd-MM-yy hh:mm tt")
            };

            // tính tổng tiền các item trong giỏ
            var total = 0;

            foreach (var item in List.Cart)
            {
                total += int.Parse(item.Sum.ToString());
            }

            bill.Total = total;

            var newData = oldData.Remove(oldData.Length - 2) + "," + JsonConvert.SerializeObject(bill) + "]}";

            File.WriteAllText(Execute.GetFilePath("bill"), newData);

            // sửa lại số lượng trong kho và xóa trắng giỏ hàng
            Edit.Quantity();
            List.Cart.Clear();
        }

        public static void Cart(DataGridView dataGridView, NumericUpDown numericUpDown)
        {
            var currentRow = dataGridView.CurrentRow;

            if (numericUpDown.Value == 0) return;
            // tính thành tiền cho item được thêm vào giỏ
            var sum = numericUpDown.Value * decimal.Parse(currentRow.Cells["Price"].Value?.ToString());
            // tìm item có trong giỏ theo ID
            var value = List.Cart.Find(s => s.ProductID.ToString() == currentRow.Cells["ID"].Value?.ToString());

            if (value != null) // nếu item đã có trong giỏ
            {
                Warning.ExistItem();
                return;
            }

            var detail = new BillDetail()
            {
                BillID = BindingList.Bill.Count,
                ProductID = currentRow.Cells["ID"].Value,
                ProductName = currentRow.Cells["Name"].Value,
                Price = currentRow.Cells["Price"].Value,
                Count = numericUpDown.Value,
                Sum = (int)sum
            };

            List.Cart.Add(detail);

            // trừ đi số hàng còn trong kho
            BindingList.Product.Where(s => s.ID.ToString() == dataGridView.CurrentRow.Cells["ID"].Value.ToString()).ToList()
                .ForEach(s => s.Quantity = decimal.Parse(s.Quantity.ToString()) - numericUpDown.Value);
            // hiển thị lại số lượng trong kho
            dataGridView.DataSource = BindingList.Product;
        }

        public static void Customer(DataGridView dataGridView)
        {
            var oldData = File.ReadAllText(Execute.GetFilePath("customer")).Trim();

            var customer = new Customer()
            {
                ID = dataGridView.RowCount.ToString(),
                Name = dataGridView.CurrentRow.Cells["Name"].Value,
                Address = dataGridView.CurrentRow.Cells["Address"].Value,
                PhoneNumber = dataGridView.CurrentRow.Cells["PhoneNumber"].Value,
                Email = dataGridView.CurrentRow.Cells["Email"].Value
            };

            var newData = oldData.Remove(oldData.Length - 2) + "," + JsonConvert.SerializeObject(customer) + "]}";

            File.WriteAllText(Execute.GetFilePath("customer"), newData);
        }

        public static void Employee(DataGridView dataGridView)
        {
            var oldData = File.ReadAllText(Execute.GetFilePath("employee")).Trim();

            var employee = new Employee()
            {
                ID = dataGridView.RowCount.ToString(),
                Name = dataGridView.CurrentRow.Cells["Name"].Value,
                Address = dataGridView.CurrentRow.Cells["Address"].Value,
                PhoneNumber = dataGridView.CurrentRow.Cells["PhoneNumber"].Value,
                Age = dataGridView.CurrentRow.Cells["Age"].Value,
                Salary = dataGridView.CurrentRow.Cells["Salary"].Value,
                Worktime = dataGridView.CurrentRow.Cells["Worktime"].Value
            };

            var newData = oldData.Remove(oldData.Length - 2) + "," + JsonConvert.SerializeObject(employee) + "]}";

            File.WriteAllText(Execute.GetFilePath("employee"), newData);
        }

        public static void Product(DataGridView dataGridView)
        {
            var oldData = File.ReadAllText(Execute.GetFilePath("product")).Trim();

            var product = new Product()
            {
                ID = dataGridView.RowCount.ToString(),
                Name = dataGridView.CurrentRow.Cells["Name"].Value,
                Origin = dataGridView.CurrentRow.Cells["Origin"].Value,
                Quantity = dataGridView.CurrentRow.Cells["Quantity"].Value,
                Price = dataGridView.CurrentRow.Cells["Price"].Value,
                ImportDate = dataGridView.CurrentRow.Cells["ImportDate"].Value,
                Expiration = dataGridView.CurrentRow.Cells["Expiration"].Value,
                Description = dataGridView.CurrentRow.Cells["Description"].Value
            };

            var newData = oldData.Remove(oldData.Length - 2) + "," + JsonConvert.SerializeObject(product) + "]}";

            File.WriteAllText(Execute.GetFilePath("product"), newData);
        }
    }
}
