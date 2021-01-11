using FruitStoreManager.Forms;
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
            if (Check.Account(textBox1.Text, textBox2.Text)) form.Hide();

            else Error.Login();

            textBox1.ResetText();
            textBox2.ResetText();
        }

        public static void ButtonLogout(Form form)
        {
            if (!Question.Logout()) return;

            new LoginForm().Show();
            form.Close();
        }

        public static void ButtonQuit()
        {
            if (!Question.Quit()) return;

            Application.Exit();
        }

        public static void ButtonDetail(DataGridView dataGridView, RichTextBox richTextBox)
        {
            if (!Check.Cart())
            {
                Display.Detail(dataGridView, richTextBox);
            }
            else
            {
                if (!Question.Detail()) return;

                Item.DetailList.Clear();
                Display.Detail(dataGridView, richTextBox);
            }
        }   

        public static void ButtonAdd(TabControl tabControl, DataGridView dataGridView, Button button)
        {
            if (button.Text == "Add")
            {
                button.Text = "Save";
                dataGridView.AllowUserToAddRows = true;
            }
            else
            {
                if (!Question.Add()) return;

                button.Text = "Add";
                dataGridView.AllowUserToAddRows = false;
                
                switch (tabControl.SelectedTab.Text)
                {
                    case "Customer":
                        if (Check.Customer(dataGridView)) Add.Customer(dataGridView);
                        break;
                    case "Bill":
                        Add.Bill(dataGridView);
                        break;
                }
            }    
        }

        public static void ButtonEdit(TabControl tabControl, DataGridView dataGridView)
        {
            switch (tabControl.SelectedTab.Text)
            {
                case "Customer":
                    Execute.Edit(dataGridView, "customer");
                    break;
            }
        }

        public static void ButtonDelete(Account account, TabControl tabControl, DataGridView dataGridView)
        {
            switch (tabControl.SelectedTab.Text)
            {
                case "Product":
                    if (account.Permission.ToString() == "Admin")
                    {

                    }   
                    else
                    {
                        Item.Detele(dataGridView);
                    }    
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
                            products = Display.ProductList.ToList().FindAll(s => s.ID.ToString() == textBox.Text);
                            dataGridView.DataSource = new BindingList<Product>(products);
                            break;
                        case "Name":
                            products = Display.ProductList.ToList().FindAll(s => s.Name.ToString().ToLower() == textBox.Text.ToLower());
                            dataGridView.DataSource = new BindingList<Product>(products);
                            break;
                        case "Origin":
                            products = Display.ProductList.ToList().FindAll(s => s.Origin.ToString().ToLower() == textBox.Text.ToLower());
                            dataGridView.DataSource = new BindingList<Product>(products);
                            break;
                        case "Price":
                            products = Display.ProductList.ToList().FindAll(s => s.Price.ToString() == textBox.Text);
                            dataGridView.DataSource = new BindingList<Product>(products);
                            break;
                        case "Quantity":
                            products = Display.ProductList.ToList().FindAll(s => s.Quantity.ToString() == textBox.Text);
                            dataGridView.DataSource = new BindingList<Product>(products);
                            break;
                        case "Import date":
                            products = Display.ProductList.ToList().FindAll(s => s.ImportDate.ToString() == textBox.Text);
                            dataGridView.DataSource = new BindingList<Product>(products);
                            break;
                        case "Expiration time":
                            products = Display.ProductList.ToList().FindAll(s => s.ExpirationTime.ToString() == textBox.Text);
                            dataGridView.DataSource = new BindingList<Product>(products);
                            break;
                        case "Description":
                            products = Display.ProductList.ToList().FindAll(s => s.Description.ToString().ToLower() == textBox.Text.ToLower());
                            dataGridView.DataSource = new BindingList<Product>(products);
                            break;
                    }
                    break;

                case "Bill":
                    var bills = new List<Bill>();

                    switch (comboBox.SelectedItem)
                    {
                        case "ID":
                            bills = Display.BillList.ToList().FindAll(s => s.ID.ToString() == textBox.Text);
                            dataGridView.DataSource = new BindingList<Bill>(bills);
                            break;
                        case "Customer name":
                            bills = Display.BillList.ToList().FindAll(s => s.CustomerName.ToString() == textBox.Text);
                            dataGridView.DataSource = new BindingList<Bill>(bills);
                            break;
                        case "Time":
                            bills = Display.BillList.ToList().FindAll(s => s.Time.ToString().ToLower() == textBox.Text.ToLower());
                            dataGridView.DataSource = new BindingList<Bill>(bills);
                            break;
                        case "Total":
                            bills = Display.BillList.ToList().FindAll(s => s.Total.ToString() == textBox.Text);
                            dataGridView.DataSource = new BindingList<Bill>(bills);
                            break;
                        case "Payment method":
                            bills = Display.BillList.ToList().FindAll(s => s.PaymentMethod.ToString().ToLower() == textBox.Text.ToLower());
                            dataGridView.DataSource = new BindingList<Bill>(bills);
                            break;
                    }
                    break;

                case "Customer":
                    var customers = new List<Customer>();

                    switch (comboBox.SelectedItem)
                    {
                        case "ID":
                            customers = Display.CustomerList.ToList().FindAll(s => s.ID.ToString() == textBox.Text);
                            dataGridView.DataSource = new BindingList<Customer>(customers);
                            break;
                        case "Name":
                            customers = Display.CustomerList.ToList().FindAll(s => s.Name.ToString().ToLower() == textBox.Text.ToLower());
                            dataGridView.DataSource = new BindingList<Customer>(customers);
                            break;
                        case "Address":
                            customers = Display.CustomerList.ToList().FindAll(s => s.Address.ToString().ToLower() == textBox.Text.ToLower());
                            dataGridView.DataSource = new BindingList<Customer>(customers);
                            break;
                        case "Phone number":
                            customers = Display.CustomerList.ToList().FindAll(s => s.PhoneNumber.ToString() == textBox.Text);
                            dataGridView.DataSource = new BindingList<Customer>(customers);
                            break;
                        case "Email":
                            customers = Display.CustomerList.ToList().FindAll(s => s.Email.ToString().ToLower() == textBox.Text.ToLower());
                            dataGridView.DataSource = new BindingList<Customer>(customers);
                            break;
                    }
                    break;
            }
        }
    }
}
