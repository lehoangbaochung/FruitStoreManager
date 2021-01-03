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

        public static void Detail(DataGridView dataGridView, RichTextBox richTextBox)
        {
            string detail = null;

            var detailsList = BillDetailList.FindAll(s => s.BillID == dataGridView.CurrentRow.Cells[0].Value.ToString());

            for (int i = 0; i < detailsList.Count; i++)
            {
                detail += string.Format("Product ID: {0}\nProduct name: {1}\nCount: {2}\nPrice: {3}\nSum: {4}\n\n",
                    detailsList[i].ProductID, detailsList[i].ProductName, detailsList[i].Count, detailsList[i].Price, detailsList[i].Sum);
            }

            richTextBox.Text = detail;
        }

        private static void BillDetail()
        {
            BillDetailList.Clear();

            foreach (var item in DataManagement.Read(@"Data\billdetail.json")["billdetail"])
            {
                var detail = new BillDetail()
                {
                    BillID = item["BillID"],
                    ProductID = item["ProductID"],
                    ProductName = item["ProductName"],
                    Count = item["Count"],
                    Price = item["Price"]
                };

                detail.Sum = (int.Parse(detail.Count) * int.Parse(detail.Price)).ToString();

                BillDetailList.Add(detail);
            }
        }

        public static void Bill(DataGridView dataGridView)
        {
            BillDetail();

            foreach (var item in DataManagement.Read(@"Data\bill.json")["bill"])
            {
                var bill = new Bill()
                {
                    ID = item["ID"],
                    CustomerID = item["CustomerID"],
                    EmployeeID = item["EmployeeID"],
                    PaymentMethod = item["PaymentMethod"]
                };

                var list = BillDetailList.FindAll(s => s.BillID == bill.ID).ToList();
                int total = 0;

                foreach (var product in list) total += int.Parse(product.Sum);

                bill.Total = total.ToString();

                BillList.Add(bill);
            }

            dataGridView.DataSource = BillList;
        }

        public static void Product(DataGridView dataGridView)
        {
            foreach (var item in DataManagement.Read(@"Data\product.json")["product"])
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

                ProductList.Add(product);
            }

            dataGridView.DataSource = ProductList;
        }

        public static void Customer(DataGridView dataGridView)
        {
            foreach (var item in DataManagement.Read(@"Data\customer.json")["customer"])
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

            dataGridView.DataSource = CustomerList;
        }

        public static void Employee(DataGridView dataGridView)
        {
            foreach (var item in DataManagement.Read(@"Data\employee.json")["employee"])
            {
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
            foreach (var item in DataManagement.Read(@"Data\account.json")["account"])
            {
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
    }
}
