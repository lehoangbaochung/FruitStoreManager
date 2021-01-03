using FruitStoreManager.Models;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    class Event
    {
        public static void Load(Form form, Account account, TabControl tabControl)
        {
            form.Text = "F99 Fruit Store Manager - Permission: " + account.Permission + " - Username: " + account.Username;

            if (account.Permission == "Admin")
            {
                tabControl.TabPages.Add("Employee");
                tabControl.TabPages.Add("Statistics");
                tabControl.TabPages.Add("Account");

                MessageBox.Show("You are logged in as an administrator!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                tabControl.TabPages.Add("Customer");
                tabControl.TabPages.Add("Bill");

                MessageBox.Show("You are logged in as an employee!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void TabControl(TabControl tabControl, ComboBox comboBox, DataGridView dataGridView, RichTextBox richTextBox)
        {
            dataGridView.Rows.Clear();
            richTextBox.ResetText();
            comboBox.Items.Clear();
            comboBox.ResetText();

            switch (tabControl.SelectedTab.Text)
            {
                case "Product":
                    Display.Product(dataGridView);
                    comboBox.Items.AddRange(new string[] { "ID", "Name", "Origin", "Quantity", "Price", "Import Date", "Expiration Time", "Description" });
                    break;
                case "Bill":
                    Display.Bill(dataGridView);
                    comboBox.Items.AddRange(new string[] { "ID", "Customer ID", "Employee ID", "Total", "Payment Method" });
                    break;
                case "Customer":
                    Display.Customer(dataGridView);
                    comboBox.Items.AddRange(new string[] { "ID", "Name", "Address", "PhoneNumber", "Email" });
                    break;
                case "Employee":
                    Display.Employee(dataGridView);
                    comboBox.Items.AddRange(new string[] { "ID", "Name", "Age", "Address", "PhoneNumber", "Salary", "Worktime" });
                    break;
                case "Statistics":
                    break;
                case "Account":
                    Display.Account(dataGridView);
                    comboBox.Items.AddRange(new string[] { "Username", "Permission" });
                    break;
            }

            //dataGridView.Columns[0].ReadOnly = true;
        }

        public static void ButtonEnabled(TabControl tabControl, Button btnAdd, Button btnEdit, Button btnDelete, Button btnDetail)
        {
            switch (tabControl.SelectedTab.Text)
            {
                case "Product":
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnDetail.Enabled = false;
                    break;
                case "Bill":
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnDetail.Enabled = true;
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
            }
        }
    }
}
