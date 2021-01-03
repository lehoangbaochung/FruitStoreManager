using FruitStoreManagement.Forms;
using FruitStoreManager.Functions;
using FruitStoreManager.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace FruitStoreManager.Events
{
    class Clicked
    {
        public static void ButtonLogin(Form form, TextBox textBox1, TextBox textBox2)
        {
            if (!Check.Account(textBox1.Text, textBox2.Text))
                MessageBox.Show("Username or Password is not valid!", "Log in", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                form.Hide();

            textBox1.ResetText();
            textBox2.ResetText();
        }

        public static void ButtonLogout(Form form)
        {
            var result = MessageBox.Show("Are you sure to log out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            var loginForm = new LoginForm();
            loginForm.Show();
            form.Close();
        }

        public static void ButtonQuit()
        {
            var result = MessageBox.Show("Are you sure to quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return;
            
            Application.Exit();
        }

        public static void ButtonDetails(TabControl tabControl, DataGridView dataGridView, RichTextBox richTextBox)
        {
            richTextBox.ResetText();

            switch (tabControl.SelectedTab.Text)
            {
                case "Bill":
                    Display.Detail(dataGridView, richTextBox);
                    break;
            }
        }

        public static void ButtonAdd(TabControl tabControl, DataGridView dataGridView, Button button)
        {
            var result = MessageBox.Show("Are you sure to add this values?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            switch (tabControl.SelectedTab.Text)
            {
                case "Customer":
                    if (button.Text == "Add")
                    {
                        button.Text = "Save";
                        dataGridView.AllowUserToAddRows = true;
                    }
                    else
                    {
                        button.Text = "Add";
                        dataGridView.AllowUserToAddRows = false;
                        Add.Customer(dataGridView);
                    }
                    break;
            }
        }

        public static void ButtonEdit(TabControl tabControl, DataGridView dataGridView)
        {
            var result = MessageBox.Show("Are you sure to edit this value?", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            switch (tabControl.SelectedTab.Text)
            {
                case "Product":
                    DataManagement.Edit(dataGridView, "product");
                    break;
                case "Customer":
                    DataManagement.Edit(dataGridView, "customer");
                    break;
            }
        }

        public static void ButtonSearch(TabControl tabControl, ComboBox comboBox, TextBox textBox, DataGridView dataGridView)
        {
            switch (tabControl.SelectedTab.Text)
            {
                case "Product":
                    var products = new List<Product>();

                    switch (comboBox.SelectedItem)
                    {
                        case "ID":
                            products = Display.ProductList.ToList().FindAll(s => s.ID == textBox.Text);
                            dataGridView.DataSource = new BindingList<Product>(products);
                            break;
                        case "Name":
                            products = Display.ProductList.ToList().FindAll(s => s.Name.ToLower() == textBox.Text.ToLower());
                            dataGridView.DataSource = new BindingList<Product>(products);
                            break;
                        case "Origin":
                            products = Display.ProductList.ToList().FindAll(s => s.Origin.ToLower() == textBox.Text.ToLower());
                            dataGridView.DataSource = new BindingList<Product>(products);
                            break;
                        case "Price":
                            products = Display.ProductList.ToList().FindAll(s => s.Price == textBox.Text);
                            dataGridView.DataSource = new BindingList<Product>(products);
                            break;
                        case "Quantity":
                            products = Display.ProductList.ToList().FindAll(s => s.Quantity == textBox.Text);
                            dataGridView.DataSource = new BindingList<Product>(products);
                            break;
                        case "Import Date":
                            products = Display.ProductList.ToList().FindAll(s => s.ImportDate == textBox.Text);
                            dataGridView.DataSource = new BindingList<Product>(products);
                            break;
                        case "Expiration Time":
                            products = Display.ProductList.ToList().FindAll(s => s.ExpirationTime == textBox.Text);
                            dataGridView.DataSource = new BindingList<Product>(products);
                            break;
                        case "Description":
                            products = Display.ProductList.ToList().FindAll(s => s.Description.ToLower() == textBox.Text.ToLower());
                            dataGridView.DataSource = new BindingList<Product>(products);
                            break;
                    }
                    break;

                case "Bill":
                    var bills = new List<Bill>();

                    switch (comboBox.SelectedItem)
                    {
                        case "ID":
                            bills = Display.BillList.ToList().FindAll(s => s.ID == textBox.Text);
                            dataGridView.DataSource = new BindingList<Bill>(bills);
                            break;
                        case "Customer ID":
                            bills = Display.BillList.ToList().FindAll(s => s.CustomerID == textBox.Text);
                            dataGridView.DataSource = new BindingList<Bill>(bills);
                            break;
                        case "Staff ID":
                            bills = Display.BillList.ToList().FindAll(s => s.EmployeeID.ToLower() == textBox.Text.ToLower());
                            dataGridView.DataSource = new BindingList<Bill>(bills);
                            break;
                        case "Total":
                            bills = Display.BillList.ToList().FindAll(s => s.Total == textBox.Text);
                            dataGridView.DataSource = new BindingList<Bill>(bills);
                            break;
                        case "Payment Method":
                            bills = Display.BillList.ToList().FindAll(s => s.PaymentMethod.ToLower() == textBox.Text.ToLower());
                            dataGridView.DataSource = new BindingList<Bill>(bills);
                            break;
                    }
                    break;

                case "Customer":
                    var customers = new List<Customer>();

                    switch (comboBox.SelectedItem)
                    {
                        case "ID":
                            customers = Display.CustomerList.ToList().FindAll(s => s.ID == textBox.Text);
                            dataGridView.DataSource = new BindingList<Customer>(customers);
                            break;
                        case "Name":
                            customers = Display.CustomerList.ToList().FindAll(s => s.Name.ToLower() == textBox.Text.ToLower());
                            dataGridView.DataSource = new BindingList<Customer>(customers);
                            break;
                        case "Address":
                            customers = Display.CustomerList.ToList().FindAll(s => s.Address.ToLower() == textBox.Text.ToLower());
                            dataGridView.DataSource = new BindingList<Customer>(customers);
                            break;
                        case "PhoneNumber":
                            customers = Display.CustomerList.ToList().FindAll(s => s.PhoneNumber == textBox.Text);
                            dataGridView.DataSource = new BindingList<Customer>(customers);
                            break;
                        case "Email":
                            customers = Display.CustomerList.ToList().FindAll(s => s.Email.ToLower() == textBox.Text.ToLower());
                            dataGridView.DataSource = new BindingList<Customer>(customers);
                            break;
                    }
                    break;
            }
        }
    }
}
