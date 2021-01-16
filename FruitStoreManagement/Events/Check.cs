using FruitStoreManager.Models;
using System.Windows.Forms;
using System.Linq;
using FruitStoreManager.Forms;

namespace FruitStoreManager.Events
{
    class Check
    {
        public static Account AccountInfo;
        
        public static bool Account(string username, string password)
        {
            AccountInfo = BindingList.Account.ToList().Find(s => s.ID.ToString() == username && s.Password.ToString() == password);

            if (AccountInfo == null) return false;

            new MainForm().Show();
            return true;
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
            if (List.Cart.Count == 0) return false;
            else return true;
        }
    }
}
