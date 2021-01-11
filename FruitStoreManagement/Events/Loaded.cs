using FruitStoreManager.Models;
using FruitStoreManager.Events;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    class Loaded
    {
        public static void Form(Form form, Account account, TabControl tabControl)
        {
            if (account.Permission.ToString() == "Admin")
            {
                tabControl.TabPages.Add("Employee");
                tabControl.TabPages.Add("Account");
                tabControl.TabPages.Add("Statistics");
            }
            else
            {
                tabControl.TabPages.Add("Bill");
                tabControl.TabPages.Add("Customer");
            }

            form.Text = "F99 Fruit Store Manager - Permission: " + account.Permission + " - Username: " + account.Username;
            Information.LoginPermission(account);
        }

        public static void TabControl(TabControl tabControl, ComboBox comboBox, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            comboBox.Items.Clear();
            comboBox.ResetText();

            switch (tabControl.SelectedTab.Text)
            {
                case "Product":
                    Display.Product(dataGridView);
                    comboBox.Items.AddRange(new string[] { "ID", "Name", "Origin", "Quantity", "Price", "Import date", "Expiration time", "Description" });
                    break;
                case "Bill":
                    Display.Bill(dataGridView);
                    comboBox.Items.AddRange(new string[] { "ID", "Customer name", "Time", "Total", "Payment method" });
                    break;
                case "Customer":
                    Display.Customer(dataGridView);
                    comboBox.Items.AddRange(new string[] { "ID", "Name", "Address", "Phone Number", "Email" });
                    break;
                case "Employee":
                    Display.Employee(dataGridView);
                    comboBox.Items.AddRange(new string[] { "ID", "Name", "Age", "Address", "Phone number", "Salary", "Worktime" });
                    break;
                case "Statistics":
                    comboBox.Items.AddRange(new string[] { "Sale", "Product", "Employee" });
                    break;
                case "Account":
                    Display.Account(dataGridView);
                    comboBox.Items.AddRange(new string[] { "Username", "Permission" });
                    break;
            }

            dataGridView.Columns[0].ReadOnly = true;
        }

        public static void Button(TabControl tabControl, Button btnAdd, Button btnEdit, Button btnDelete, Button btnDetail)
        {
            switch (tabControl.SelectedTab.Text)
            {
                case "Bill":
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnDetail.Enabled = true;

                    if (Item.DetailList.Count == 0)
                        btnAdd.Enabled = false;
                    else
                        btnAdd.Enabled = true;
                    break;
                case "Customer":
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = false;
                    btnDetail.Enabled = false;
                    break;
                case "Employee":
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    btnDetail.Enabled = false;
                    break;
                case "Account":
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    btnDetail.Enabled = false;
                    break;
                case "Statistics":
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnDetail.Enabled =true;
                    break;
            }
        }
    }
}
