using FruitStoreManager.Forms;
using FruitStoreManager.Models;
using FruitStoreManager.Functions;
using System.Windows.Forms;

namespace FruitStoreManager.Events
{
    class Check
    {
        public static Account AccountInfo;
        
        public static bool Account(string username, string password)
        {
            foreach (var item in Execute.Read("account")["account"])
            {
                AccountInfo = new Account()
                {
                    Username = item["Username"],
                    Password = item["Password"],
                    Permission = item["Permission"]
                };

                if (AccountInfo.Username.ToString() == username && AccountInfo.Password.ToString() == password)
                {
                    new MainForm().Show();
                    return true;
                }
            }

            return false;
        }

        public static bool Product(DataGridView dataGridView)
        {
            var currentRow = dataGridView.CurrentRow;

            foreach (var item in currentRow.Cells)
            {
                if (item == null) return false;
            }

            return true;
        }

        public static bool Customer(DataGridView dataGridView)
        {
            var currentRow = dataGridView.CurrentRow;
   
            if (currentRow.Cells["Name"].Value == null || currentRow.Cells["Address"].Value == null)
            {
                Warning.NullValue();
                return false;
            }
            else if (currentRow.Cells["PhoneNumber"].Value != null)
            {
                if (int.TryParse(currentRow.Cells["PhoneNumber"].Value.ToString(), out int number))
                {
                    Warning.InputFormat();
                    return false;
                }
            }
            else if (currentRow.Cells["Email"].Value != null)
            {
                if (!currentRow.Cells["Email"].Value.ToString().Contains("@"))
                {
                    Warning.InputFormat();
                    return false;
                }
            }

            return true;
        }

        public static bool Cart()
        {
            if (Item.DetailList.Count == 0) return false;
            else return true;
        }
    }
}
