using FruitStoreManager.Events;
using FruitStoreManager.Functions;
using System;
using System.Windows.Forms;

namespace FruitStoreManager.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
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

            Event.Load(this, Check.AccountInfo, tabCtrl);
        }

        private void tabctrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxSearch.ResetText();
            Event.TabControl(tabCtrl, cbxFilter, dgvTable, rtbxDetail);
            Event.ButtonEnabled(tabCtrl, btnAdd, btnEdit, btnDelete, btnDetail);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Clicked.ButtonSearch(tabCtrl, cbxFilter, tbxSearch, dgvTable);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Clicked.ButtonAdd(tabCtrl, dgvTable, btnAdd);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Clicked.ButtonEdit(tabCtrl, dgvTable);
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Clicked.ButtonDetails(tabCtrl, dgvTable, rtbxDetail);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Clicked.ButtonLogout(this);
        }
    }
}
