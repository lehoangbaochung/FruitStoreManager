using FruitStoreManager.Events;
using FruitStoreManager.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    internal class Add
    {
        private static void Value(string fileName, object obj)
        {
            var oldData = File.ReadAllText(Execute.GetFilePath(fileName)).Trim();
            var subString = oldData.Remove(oldData.Length - 2);

            if (subString.EndsWith("]")) // exception substring has issue
            {
                subString = subString.Remove(oldData.Length - 1);
            }

            string newData;

            if (subString.EndsWith("[")) // add first value
                newData = subString + JsonConvert.SerializeObject(obj) + "]}";
            else // another values
                newData = subString + "," + JsonConvert.SerializeObject(obj) + "]}";

            File.WriteAllText(Execute.GetFilePath(fileName), newData);
            MessageBox.Show("Successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Account(DataGridView dataGridView)
        {
            var account = new Account()
            {
                ID = dataGridView.CurrentRow.Cells["ID"].Value,
                Password = dataGridView.CurrentRow.Cells["Password"].Value,
                Permission = dataGridView.CurrentRow.Cells["Permission"].Value
            };

            if (!Check.Account(account)) return;

            Value("account", account);
        }

        public static void BillDetail() // thêm các item trong giỏ vào file billdetail
        {
            string newItem = null;

            foreach (var item in List.Cart)
            {
                newItem += JsonConvert.SerializeObject(item) + ",";
                Value("billdetail", item);
            }
        }

        public static void Bill(DataGridView dataGridView)
        {
            BillDetail();

            var bill = new Bill()
            {
                ID = BindingList.Bill.Count + 1,
                EmployeeID = Check.AccountInfo.ID,
                CustomerName = dataGridView.CurrentRow.Cells["CustomerName"].Value,
                PaymentMethod = dataGridView.CurrentRow.Cells["PaymentMethod"].Value,
                Time = DateTime.Now.ToString("dd-MM-yy hh:mm tt")
            };

            if (!Check.Bill(bill)) return;

            // tính tổng tiền các item trong giỏ
            var total = 0;

            foreach (var item in List.Cart) total += int.Parse(item.Sum.ToString());

            bill.Total = total;

            Value("bill", bill);

            // sửa lại số lượng trong kho và xóa trắng giỏ hàng
            Edit.Quantity();
            List.Cart.Clear();
        }

        public static void Cart(DataGridView dataGridView, NumericUpDown numericUpDown)
        {
            if (!Check.Cart(dataGridView, numericUpDown)) return;

            var currentRow = dataGridView.CurrentRow;

            // tính thành tiền cho item được thêm vào giỏ
            var sum = numericUpDown.Value * decimal.Parse(currentRow.Cells["Price"].Value?.ToString());
            // tìm item có trong giỏ theo ID
            var value = List.Cart.Find(s => s.ProductID.ToString() == currentRow.Cells["ID"].Value?.ToString());

            if (value != null) // nếu item đã có trong giỏ
            {
                Warning.Exist();
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
            var customer = new Customer()
            {
                ID = dataGridView.RowCount.ToString(),
                Name = dataGridView.CurrentRow.Cells["Name"].Value,
                Address = dataGridView.CurrentRow.Cells["Address"].Value,
                PhoneNumber = dataGridView.CurrentRow.Cells["PhoneNumber"].Value,
                Email = dataGridView.CurrentRow.Cells["Email"].Value
            };

            if (!Check.Customer(customer)) return;

            Value("customer", customer);
        }

        public static void Employee(DataGridView dataGridView)
        {
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

            if (!Check.Employee(employee)) return;

            Value("employee", employee);
            Request(employee);
        }

        public static void Product(DataGridView dataGridView)
        {
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

            if (!Check.Product(product)) return;

            Value("product", product);
        }

        private static void Request(Employee employee)
        {
            var request = new Request[]
            {
                new Request() { EmployeeID = employee.ID, Title = "Sửa thông tin" },
                new Request() { EmployeeID = employee.ID, Title = "Chấm công" },
                new Request() { EmployeeID = employee.ID, Title = "Nghỉ việc"}
            };

            foreach (var item in request)
            {
                Value("request", item);
            }    
        }
    }
}
