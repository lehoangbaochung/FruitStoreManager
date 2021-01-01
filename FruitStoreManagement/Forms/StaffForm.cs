using FruitStoreManager.Data;
using FruitStoreManager.Models;
using FruitStoreManager.Staff;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FruitStoreManager.Forms
{
    public partial class StaffForm : Form
    {
        static int TableRowsCount;

        public StaffForm()
        {
            InitializeComponent();

            MessageBox.Show("Bạn đang đăng nhập với vai trò nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void StaffForm_Load(object sender, EventArgs e)
        {
            //string[] header = { "ID", "Name", "Phone", "Address", "Email" };

            //for (int i = 0; i < header.Length; i++)
            //{
            //    var cell = new DataGridViewTextBoxCell();

            //    var column = new DataGridViewColumn()
            //    { 
            //        HeaderText = header[i],
            //        CellTemplate = cell
            //    };

            //    dgvCustomer.Columns.Add(column);
            //}

            //var element = new SubForm()
            //{
            //    Table = dgvCustomer,
            //    Search = tbxSearch,
            //    TableRowsCount = dgvCustomer.RowCount
            //};

            //Add.Customer(element);
        }


        private void btAdd_Click(object sender, EventArgs e)
        {
            TableRowsCount = dgvTable.Rows.Count;
            label1.Text = TableRowsCount.ToString();

            if (btAdd.Text == "Thêm")
            {
                btAdd.Text = "Lưu";
                dgvTable.AllowUserToAddRows = true;                
            }
            else
            {
                btAdd.Text = "Thêm";
                dgvTable.AllowUserToAddRows = false;

            }    
        }

        private void tabctrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabctrl.SelectedIndex == 1)
            {
                ProductManagement.Display(dgvTable);
            }

            if (tabctrl.SelectedIndex == 1)
            {
                ProductManagement.Display(dgvTable);
            }    
        }
    }
}
