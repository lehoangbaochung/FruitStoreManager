using FruitStoreManager.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    class Display
    {
        public static readonly List<BillDetail> BillDetailList = new List<BillDetail>();
        public static readonly BindingList<Bill> BillList = new BindingList<Bill>();
        public static readonly BindingList<Customer> CustomerList = new BindingList<Customer>();
        public static readonly BindingList<Product> ProductList = new BindingList<Product>();
        public static readonly BindingList<Account> AccountList = new BindingList<Account>();
        public static readonly BindingList<Employee> EmployeeList = new BindingList<Employee>();

        private static void BillDetail()
        {
            BillDetailList.Clear();

            foreach (var item in Execute.Read("billdetail")["billdetail"])
            {
                var detail = new BillDetail()
                {
                    BillID = item["BillID"],
                    ProductID = item["ProductID"],
                    ProductName = item["ProductName"],
                    Count = item["Count"],
                    Price = item["Price"]
                };

                detail.Sum = (int.Parse(detail.Count.ToString()) * int.Parse(detail.Price.ToString())).ToString();

                BillDetailList.Add(detail);
            }
        }

        public static void Bill(DataGridView dataGridView)
        {
            BillDetail();

            foreach (var item in Execute.Read("bill")["bill"])
            {
                var bill = new Bill()
                {
                    ID = item["ID"],
                    CustomerName = item["CustomerName"],
                    EmployeeID = item["EmployeeID"],
                    Time = item["Time"],
                    PaymentMethod = item["PaymentMethod"]
                };

                var list = BillDetailList.FindAll(s => s.BillID.ToString() == bill.ID.ToString()).ToList();
                int total = 0;

                foreach (var product in list) total += int.Parse(product.Sum.ToString());

                bill.Total = total.ToString();
                BillList.Add(bill);
            }

            dataGridView.DataSource = BillList;

            //dataGridView.Columns["EmployeeID"].Visible = false;
            //dataGridView.Columns["Time"].ReadOnly = true;
        }

        public static void Product(DataGridView dataGridView)
        {
            foreach (var item in Execute.Read("product")["product"])
            {
                if (item["ID"] == null) return;

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
                
                ProductList.Add(product);
            }

            dataGridView.DataSource = ProductList;
        }

        public static void Customer(DataGridView dataGridView)
        {
            foreach (var item in Execute.Read("customer")["customer"])
            {
                if (item["ID"] == null) return;

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

            dataGridView.DataSource = CustomerList;
        }

        public static void Employee(DataGridView dataGridView)
        {
            foreach (var item in Execute.Read("employee")["employee"])
            {
                if (item["ID"] == null) return;

                var Employee = new Employee()
                {
                    ID = item["ID"],
                    Name = item["Name"],
                    Age = item["Age"],
                    Address = item["Address"],
                    PhoneNumber = item["PhoneNumber"],
                    Salary = item["Salary"],
                    Worktime = item["Worktime"]
                };

                EmployeeList.Add(Employee);
            }

            dataGridView.DataSource = EmployeeList;
        }

        public static void Account(DataGridView dataGridView)
        {
            foreach (var item in Execute.Read("account")["account"])
            {
                if (item["ID"] == null) return;

                var account = new Account()
                {
                    Username = item["Username"],
                    Password = item["Password"],
                    Permission = item["Permission"]
                };

                AccountList.Add(account);
            }

            dataGridView.DataSource = AccountList;
        }

        public static void Detail(DataGridView dataGridView, RichTextBox richTextBox)
        {
            richTextBox.ResetText();

            var detailList = BillDetailList.FindAll(s => s.BillID.ToString() == dataGridView.CurrentRow.Cells[0].Value?.ToString());

            foreach (var item in detailList)
            {
                richTextBox.Text += $"Product ID: {item.ProductID}\nProduct name: {item.ProductName}\nCount: {item.Count}\nPrice: {item.Price}\nSum: {item.Sum}\n\n";
            }
        }

        public static void Cart(RichTextBox richTextBox)
        {
            richTextBox.ResetText();

            foreach (var item in Item.DetailList)
            {
                richTextBox.Text += $"Product ID: {item.ProductID}\nProduct name: {item.ProductName}\nCount: {item.Count}\nPrice: {item.Price}\nSum: {item.Sum}\n\n";
            }
        }
    }
}