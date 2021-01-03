using FruitStoreManager.Forms;
using FruitStoreManager.Models;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    class Check
    {
        public static Account AccountInfo;
        static string text = null;
        static bool check = false;
        
        public static bool Account(string username, string password)
        {
            foreach (var item in DataManagement.Read(@"Data\account.json")["account"])
            {
                AccountInfo = new Account()
                {
                    Username = item["Username"],
                    Password = item["Password"],
                    Permission = item["Permission"]
                };

                if (AccountInfo.Username == username && AccountInfo.Password == password)
                {
                    check = true;
                    username = AccountInfo.Username;

                    var form = new MainForm();
                    form.Show();
                }
            }

            return check;
        }

        public static string Null(string value)
        {
            if (value == null) MessageBox.Show("Input format is not valid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else text = value;

            return text;
        }

        public static string Email(string value)
        {
            if (value == null) text = null;
            else if (value.Contains("@")) text = value;

            return text;
        }

        public static string Integer(string value)
        {
            if (int.TryParse(value, out int number) && value != null) text = number.ToString();

            return text;
        }

        public static string Double(string value)
        {
            if (double.TryParse(value, out double number) && value != null) text = number.ToString();

            return text;
        }
    }
}
