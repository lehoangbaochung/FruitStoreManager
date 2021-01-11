using FruitStoreManager.Models;
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

        private void MainForm_Load(object sender, EventArgs e)
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

            Loaded.Form(this, Check.AccountInfo, tabCtrl);
        }

        private void tabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxSearch.ResetText();
            Loaded.TabControl(tabCtrl, cbxFilter, dgvTable);

            if (tabCtrl.SelectedTab.Text == "Product")
            {
                if (Check.AccountInfo.Permission.ToString() == "Admin")
                {
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    btnDetail.Enabled = false;
                }
                else
                {
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnDetail.Enabled = false;
                    dgvTable.ReadOnly = true;
                }
            }
            else
            {
                Loaded.Button(tabCtrl, btnAdd, btnEdit, btnDelete, btnDetail);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Clicked.ButtonSearch(tabCtrl, cbxFilter, tbxSearch, dgvTable);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (tabCtrl.SelectedTab.Text == "Product")
            {
                if (Check.AccountInfo.Permission.ToString() == "Admin")
                {
                    Add.Product(dgvTable);
                }
                else
                {
                    Item.Add(dgvTable, nudCount);
                    Display.Cart(rtbxDetail);

                    if (Item.DetailList.Count == 0)
                    {
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                }  
            }
            else
                Clicked.ButtonAdd(tabCtrl, dgvTable, btnAdd);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!Question.Edit()) return;

            if (tabCtrl.SelectedTab.Text == "Product")
            {
                if (Check.AccountInfo.Permission.ToString() == "Admin")
                    Execute.Edit(dgvTable, "product");
                else
                {
                    Item.Edit(dgvTable, nudCount);
                    Display.Cart(rtbxDetail);
                }
            }
            else
                Clicked.ButtonEdit(tabCtrl, dgvTable);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Question.Delete()) return;

            Clicked.ButtonDelete(Check.AccountInfo, tabCtrl, dgvTable);
            Display.Cart(rtbxDetail);
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Clicked.ButtonDetail(dgvTable, rtbxDetail);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Clicked.ButtonLogout(this);
        } 
    }
}
