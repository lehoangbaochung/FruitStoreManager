using FruitStoreManager.Models;

namespace FruitStoreManager.Events
{
    internal class Display
    {
        public static void Form(Account account, MainElement main)
        {
            if (account.Permission.ToString() == "Quản lý")
            {
                main.TabControl.TabPages.Insert(1, "Employee");
                main.TabControl.TabPages.Insert(2, "Account");
                main.TabControl.TabPages.Insert(3, "Statistic");
            }

            if (account.Permission.ToString() == "Nhân viên")
            {
                main.TabControl.TabPages.Insert(1, "Bill");
                main.TabControl.TabPages.Insert(2, "Customer");
            }

            main.Form.Text = "F99 Fruit Store Manager - Permission: " + account.Permission + " - ID: " + account.ID;
            Information.LoginPermission(account);
        }

        public static void Account(MainElement main)
        {
            main.ComboBox.Items.AddRange(new string[] { "ID", "Permission" });
            ///
            main.DataGridView.DataSource = BindingList.Account;
            ///
            main.ButtonAdd.Enabled = true;
            main.ButtonEdit.Enabled = true;
            main.ButtonDelete.Enabled = true;
            main.ButtonMore.Enabled = false;

            main.ButtonMore.Text = "More";
        }

        public static void Bill(MainElement main)
        {
            main.ComboBox.Items.AddRange(new string[] { "Name", "Address", "Phone Number", "Email" });
            ///
            main.DataGridView.DataSource = BindingList.Bill;
            main.DataGridView.Columns["EmployeeID"].Visible = false;
            ///
            main.ButtonEdit.Enabled = false;
            main.ButtonDelete.Enabled = false;

            if (List.Cart.Count == 0)
                main.ButtonAdd.Enabled = false;
            else
                main.ButtonAdd.Enabled = true;

            if (BindingList.Bill.Count == 0)
                main.ButtonMore.Enabled = false;
            else
                main.ButtonMore.Enabled = true;

            main.ButtonMore.Text = "Detail";
        }

        public static void BillDetail(MainElement main)
        {
            main.RichTextBox.ResetText();

            var detailList = List.BillDetail.FindAll(s => s.BillID.ToString() == main.DataGridView.CurrentRow.Cells["ID"].Value?.ToString());

            foreach (var item in detailList)
            {
                main.RichTextBox.Text += $"Product ID: {item.ProductID}\nProduct name: {item.ProductName}\nCount: {item.Count}\nPrice: {item.Price}\nSum: {item.Sum}\n\n";
            }
        }

        public static void Cart(MainElement main)
        {
            main.RichTextBox.ResetText();

            foreach (var item in List.Cart)
            {
                main.RichTextBox.Text += $"Product ID: {item.ProductID}\nProduct name: {item.ProductName}\nCount: {item.Count}\nPrice: {item.Price}\nSum: {item.Sum}\n\n";
            }
        }

        public static void Customer(MainElement main)
        {
            main.ComboBox.Items.AddRange(new string[] { "Name", "Address", "Phone Number", "Email" });
            ///
            main.DataGridView.DataSource = BindingList.Customer;
            ///
            main.ButtonAdd.Enabled = true;
            main.ButtonEdit.Enabled = true;
            main.ButtonDelete.Enabled = false;
            main.ButtonMore.Enabled = false;

            main.ButtonMore.Text = "More";
        }

        public static void Employee(MainElement main)
        {
            main.ComboBox.Items.AddRange(new string[] { "Name", "Age", "Address", "Phone number", "Salary", "Worktime" });
            ///
            main.DataGridView.DataSource = BindingList.Employee;
            main.DataGridView.Columns["EmployeeID"].Visible = true;
            ///
            main.ButtonAdd.Enabled = true;
            main.ButtonEdit.Enabled = true;
            main.ButtonDelete.Enabled = true;
            main.ButtonMore.Enabled = false;

            main.ButtonMore.Text = "More";
        }    

        public static void Product(Account account, MainElement main)
        {
            main.ComboBox.Items.AddRange(new string[] { "Name", "Origin", "Quantity", "Price", "Import date", "Expiration", "Description" });
            ///
            main.DataGridView.DataSource = BindingList.Product;
            ///
            if (account.Permission.ToString() == "Quản lý")
            {
                main.ButtonAdd.Enabled = true;
                main.ButtonEdit.Enabled = true;
                main.ButtonDelete.Enabled = true;
                main.ButtonMore.Enabled = false;

                main.ButtonMore.Text = "More";
            }
            
            if (account.Permission.ToString() == "Nhân viên")
            {
                main.ButtonAdd.Enabled = true;
                main.ButtonEdit.Enabled = false;
                main.ButtonDelete.Enabled = false;
                main.NumericUpDown.Visible = true;

                if (List.Cart.Count == 0)
                    main.ButtonMore.Enabled = false;
                else
                    main.ButtonMore.Enabled = true;

                main.ButtonMore.Text = "Cart";
            }
        }

        public static void Request(Account account, MainElement main)
        {
            main.ComboBox.Items.AddRange(new string[] { "Time", "Employee ID", "Tilte", "Content", "Status" });
            ///
            main.DataGridView.DataSource = BindingList.Request;
            ///
            if (account.Permission.ToString() == "Quản lý")
            {
                main.ButtonAdd.Enabled = false;
                main.ButtonEdit.Enabled = true;
                main.ButtonDelete.Enabled = false;
                main.ButtonMore.Enabled = false;

                main.ButtonMore.Text = "Mark";
            }

            if (account.Permission.ToString() == "Nhân viên")
            {
                main.ComboBox.Items.Remove("EmployeeID");
                ///
                main.DataGridView.Columns["EmployeeID"].Visible = false;
                main.DataGridView.Columns["Title"].ReadOnly = true;
                ///
                main.ButtonAdd.Enabled = false;
                main.ButtonEdit.Enabled = true;
                main.ButtonDelete.Enabled = false;
                main.ButtonMore.Enabled = false;

                main.ButtonMore.Text = "Send";
            }
        }

        public static void Statistic(MainElement main)
        {
            main.ComboBox.Items.AddRange(new string[] { "Day", "Month", "Year" });
            ///
            main.DataGridView.DataSource = BindingList.Statistic;
            ///
            main.ButtonAdd.Enabled = false;
            main.ButtonEdit.Enabled = false;
            main.ButtonDelete.Enabled = false;
            main.ButtonMore.Enabled = true;

            main.ButtonMore.Text = "Detail";
        }    
    }
}
