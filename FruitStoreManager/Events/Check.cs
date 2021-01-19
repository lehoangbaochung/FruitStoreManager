using FruitStoreManager.Models;
using FruitStoreManager.Forms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FruitStoreManager.Events
{
    internal class Check
    {
        public static Account AccountInfo;
        
        public static bool Login(string username, string password)
        {
            AccountInfo = BindingList.Account.ToList().Find(s => s.ID.ToString() == username && s.Password.ToString() == password);

            if (AccountInfo == null) return false;

            new MainForm().Show();
            return true;
        }

        public static bool Account(Account account)
        {
            // account existion
            if (BindingList.Account.ToList().Find(s => s.ID == account.ID) != null)
            {
                Warning.Exist();
                return false;
            }
            // not allow contains special characters
            if (!account.ID.ToString().Any(ch => !char.IsLetterOrDigit(ch)) || !account.Password.ToString().Any(ch => !char.IsLetterOrDigit(ch)))
            {
                Warning.SpecialCharacter();
                return false;
            }    
            // permission only has "Nhân viên"
            if (!account.Permission.Equals("Nhân viên"))
            {
                Warning.InputFormat();
                return false;
            }    
            return true;
        }

        public static bool Bill(Bill bill)
        {
            if (!bill.PaymentMethod.Equals("Trực tiếp") || !bill.PaymentMethod.Equals("Trực tuyến"))
            {
                Warning.InputFormat();
                return false;
            }    

            return true;
        }   

        public static bool Cart(DataGridView dataGridView, NumericUpDown numericUpDown)
        {
            if (numericUpDown.Value > Convert.ToInt32(dataGridView.CurrentRow.Cells["Quantity"].Value?.ToString()))
            {
                Warning.Exceed();
                return false;
            }

            if (numericUpDown.Value == 0 || numericUpDown.Value.ToString() == null)
            {
                Warning.InputFormat();
                return false;
            }   
            
            return true;
        }
        
        public static bool Product(Product product)
        {
            // not allow any prop be null
            if (product.Name == null || product.Origin == null || product.Quantity == null || product.Price == null
                || product.ImportDate == null || product.Expiration == null)
            {
                Warning.NullValue();
                return false;
            }  
            // quantity & price must be valid values
            if (double.TryParse(product.Quantity.ToString(), out double quantity) || int.TryParse(product.Price.ToString(), out int price)
                || product.ImportDate.ToString().Contains("-") == false)
            {
                Warning.InputFormat();
                return false;
            }   
            return true;
        }

        public static bool Customer(Customer customer)
        {
            // name & address can't be null
            if (customer.Name == null || customer.Address == null)
            {
                Warning.NullValue();
                return false;
            }
            // phone number must be an integer array & email must contain @
            if (customer.PhoneNumber != null && customer.Email != null)
            {
                if (!int.TryParse(customer.PhoneNumber.ToString(), out int number) || !customer.Email.ToString().Contains("@"))
                {
                    Warning.InputFormat();
                    return false;
                }
            }

            return true;
        }

        public static bool Employee(Employee employee)
        {
            if (double.TryParse(employee.Salary.ToString(), out double salary) || double.TryParse(employee.Worktime.ToString(), out double worktime)
                || int.TryParse(employee.PhoneNumber.ToString(), out int number) || int.TryParse(employee.Age.ToString(), out int age))
            {
                Warning.InputFormat();
                return false;
            }    

            return true;
        }

        public static bool Cart()
        {
            if (List.Cart.Count == 0) return false;
            else return true;
        }
    }
}
