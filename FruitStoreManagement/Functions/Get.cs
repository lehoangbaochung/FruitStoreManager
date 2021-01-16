using FruitStoreManager.Models;

namespace FruitStoreManager.Functions
{
    internal class Get
    {
        public static void Data(Account account)
        {
            BindingList.Account.Clear();
            BindingList.Bill.Clear();
            BindingList.Customer.Clear();
            BindingList.Employee.Clear();
            BindingList.Product.Clear();
            BindingList.Request.Clear();
            BindingList.Statistic.Clear();
            ///
            Product();
            Bill();
            Request(account);

            if (account.Permission.ToString() == "Quản lý")
            {
                Employee();
            }    

            if (account.Permission.ToString() == "Nhân viên")
            {
                Customer();
                BillDetail();
            }     
        }

        public static void Account()
        {
            foreach (var item in Execute.Read("account")["account"])
            {
                if (item["ID"] == null) return;

                var account = new Account()
                {
                    ID = item["ID"],
                    Password = item["Password"],
                    Permission = item["Permission"]
                };

                BindingList.Account.Add(account);
            }
        }

        private static void Bill()
        {
            foreach (var item in Execute.Read("bill")["bill"])
            {
                var bill = new Bill()
                {
                    ID = item["ID"],
                    CustomerName = item["CustomerName"],
                    EmployeeID = item["EmployeeID"],
                    Time = item["Time"],
                    Total = item["Total"],
                    PaymentMethod = item["PaymentMethod"]
                };

                BindingList.Bill.Add(bill);
            }
        }

        private static void BillDetail()
        {
            foreach (var item in Execute.Read("billdetail")["billdetail"])
            {
                var detail = new BillDetail()
                {
                    BillID = item["BillID"],
                    ProductID = item["ProductID"],
                    ProductName = item["ProductName"],
                    Count = item["Count"],
                    Price = item["Price"],
                    Sum = item["Sum"]
                };

                List.BillDetail.Add(detail);
            }
        }

        private static void Customer()
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

                BindingList.Customer.Add(customer);
            }
        }

        private static void Employee()
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

                BindingList.Employee.Add(Employee);
            }
        }

        private static void Product()
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
                    Expiration= item["Expiration"],
                    Description = item["Description"]
                };
                
                BindingList.Product.Add(product);
            }
        }

        private static void Request(Account account)
        {
            foreach (var item in Execute.Read("request")["request"])
            {
                if (account.Permission.ToString() == "Quản lý")
                {
                    if (item["Status"] == null) return;
                }

                var request = new Request()
                {
                    EmployeeID = item["EmployeeID"],
                    Title = item["Title"],
                    Content = item["Content"],
                    Time = item["Time"],
                    Status = item["Status"]
                };

                BindingList.Request.Add(request);
            }
        }

        private static void Statistic()
        {
            var statistic = new Statistic() 
            { 
                Time = "All",
                Employee = BindingList.Employee.Count,
                Product = BindingList.Product.Count,
                Sale = BindingList.Bill.Count
            };

            BindingList.Statistic.Add(statistic);
        }
    }
}