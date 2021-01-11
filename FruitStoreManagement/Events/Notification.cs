using FruitStoreManager.Models;
using System.Windows.Forms;

namespace FruitStoreManager.Events
{
    class Error
    {
        public static void Login()
        {
            MessageBox.Show("Username or Password is not valid!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }   
    
    class Warning
    {
        public static void InputFormat()
        {
            MessageBox.Show("Input format is not valid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void NullValue()
        {
            MessageBox.Show("These values can't be null!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ExistItem()
        {
            MessageBox.Show("This item was added into your cart!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    class Information
    {
        public static void LoginPermission(Account account)
        {
            if (account.Permission.ToString() == "Admin")
                MessageBox.Show("You are logged in as an administrator!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("You are logged in as an employee!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    class Question
    {
        public static bool Logout()
        {
            var result = MessageBox.Show("Are you sure to log out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return false;

            else return true;
        } 
        
        public static bool Quit()
        {
            var result = MessageBox.Show("Are you sure to quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return false;

            else return true;
        }
        
        public static bool Add()
        {
            var result = MessageBox.Show("Are you sure to add?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return false;

            else return true;
        }

        public static bool Edit()
        {
            var result = MessageBox.Show("Are you sure to edit?", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return false;

            else return true;
        }

        public static bool Delete()
        {
            var result = MessageBox.Show("Are you sure to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return false;

            else return true;
        }

        public static bool Detail()
        {
            var result = MessageBox.Show("Your cart is being not null. Are you sure to delete all item(s) in your cart before display details in this bill?",
                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return false;

            else return true;
        }    
    }    
}
