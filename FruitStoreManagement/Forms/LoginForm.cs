using FruitStoreManager.Databases;
using FruitStoreManager.Forms;
using System;
using System.Windows.Forms;

namespace FruitStoreManagement.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private static void Check(string username, string password)
        {
            var rows = Execute.SelectWhere("*", "Nguoidung", "ten = '" + username + ",'" + password + "'").Rows;

            if (rows.Count == 0)
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (rows[3].ToString() == "1") new StaffForm().Show();
                else new StaffForm().Show();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Check(tbxUsername.Text, tbxPassword.Text);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
