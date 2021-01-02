using FruitStoreManager.Forms;
using FruitStoreManager.Functions;
using FruitStoreManager.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace FruitStoreManagement.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private static bool Check(string username, string password)
        {
            bool check = false;

            foreach (var item in DataManagement.Read(@"Data\account.json")["account"])
            {
                var account = new Account()
                {
                    Username = item["Username"],
                    Password = item["Password"],
                    Permission = item["Permission"]
                };

                if (account.Username == username && account.Password == password)
                {
                    check = true;

                    if (account.Permission == "Admin")
                    {

                    }
                    else
                    {
                        var form = new StaffForm();
                        form.Show();
                    }
                }
            }

            return check;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Check(tbxUsername.Text, tbxPassword.Text))
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                Hide();

            tbxUsername.ResetText();
            tbxPassword.ResetText();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure to quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
