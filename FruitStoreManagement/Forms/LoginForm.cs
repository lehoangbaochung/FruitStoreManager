using FruitStoreManager.Events;
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

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FruitStoreManager.Events.Clicked.ButtonLogin(this, tbxUsername, tbxPassword);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            FruitStoreManager.Events.Clicked.ButtonQuit();
        }
    }
}
