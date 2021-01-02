using FruitStoreManagement.Forms;
using FruitStoreManager.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace FruitStoreManager.Forms
{
    public partial class StaffForm : Form
    {
        public StaffForm()
        {
            InitializeComponent();

            MessageBox.Show("Bạn đang đăng nhập với vai trò nhân viên!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void StaffForm_Load(object sender, EventArgs e)
        {
            //dgvTable.AutoGenerateColumns = false;

            //DataTable dt = new DataTable();
            //dt.Columns.Add("Name", typeof(String));
            //dt.Columns.Add("Money", typeof(String));
            //dt.Rows.Add(new object[] { "Hi", 100 });
            //dt.Rows.Add(new object[] { "Ki", 30 });

            //DataGridViewComboBoxColumn money = new DataGridViewComboBoxColumn();
            //var list11 = new List<string>() { "10", "30", "80", "100" };
            //money.DataSource = list11;
            //money.HeaderText = "Money";
            //money.DataPropertyName = "Money";

            //DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn();
            //name.HeaderText = "Name";
            //name.DataPropertyName = "Name";

            //dgvTable.DataSource = dt;
            //dgvTable.Columns.AddRange(name, money);
        }

        private void tabctrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvTable.Rows.Clear();
            rtbxDetail.ResetText();

            switch (tabctrl.SelectedIndex)
            {
                case 0:
                    CustomerManagement.Display(dgvTable);
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = false;
                    break;
                case 1:
                    ProductManagement.Display(dgvTable);
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    break;
                case 2:
                    BillManagement.Display(dgvTable);
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    break;
            }

            dgvTable.Columns[0].ReadOnly = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            switch (tabctrl.SelectedIndex)
            {
                case 0:
                    if (btnAdd.Text == "Add")
                    {
                        btnAdd.Text = "Save";
                        dgvTable.AllowUserToAddRows = true;
                    }
                    else
                    {
                        btnAdd.Text = "Add";
                        dgvTable.AllowUserToAddRows = false;
                        CustomerManagement.Add(dgvTable);
                    }
                    break;
                case 1:
                    ProductManagement.Display(dgvTable);
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    break;
                case 2:

                    BillManagement.Display(dgvTable);
                    break;
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            switch (tabctrl.SelectedIndex)
            {
                case 0:
                    DataManagement.Edit(dgvTable, "customer");
                    break;
                case 1:
                    DataManagement.Edit(dgvTable, "product");
                    break;
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            rtbxDetail.ResetText();

            switch (tabctrl.SelectedIndex)
            {
                case 2:
                    rtbxDetail.Text = BillManagement.Detail(dgvTable);
                    break;
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure to log out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var form = new LoginForm();
                form.Show();
                Close();
            }
        }
    }
}
