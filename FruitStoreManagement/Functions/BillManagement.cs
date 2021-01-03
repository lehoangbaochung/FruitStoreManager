using FruitStoreManager.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    class BillManagement
    {
        static readonly string filePath = Path.Combine(Environment.CurrentDirectory, @"Data\bill.json");
        public static readonly BindingList<Bill> BindingList = new BindingList<Bill>();
        public static readonly List<BillDetail> BillsDetailList = new List<BillDetail>();

        private static void BillDetail()
        {
            BillsDetailList.Clear();

            foreach (var item in DataManagement.Read(@"Data\billdetail.json")["billdetail"])
            {
                var detail = new BillDetail()
                {
                    BillID = item["BillID"],
                    ProductID = item["ProductID"],
                    Count = item["Count"],
                    Price = item["Price"],
                    Sum = item["Sum"]
                };

                BillsDetailList.Add(detail);
            }
        }

        public static void Display(DataGridView dataGridView)
        {
            BillDetail();

            foreach (var item in DataManagement.Read(@"Data\bill.json")["bill"])
            {
                var bill = new Bill()
                {
                    ID = item["ID"],
                    CustomerID = item["CustomerID"],
                    EmployeeID = item["StaffID"],
                    PaymentMethod = item["PaymentMethod"]
                };

                var list = BillsDetailList.FindAll(s => s.BillID == bill.ID).ToList();
                int total = 0;

                foreach (var index in list)
                {
                    total += int.Parse(index.Sum);
                }

                bill.Total = total.ToString();

                BindingList.Add(bill);
            }

            dataGridView.DataSource = BindingList;   
        }

        public static string Detail(DataGridView dataGridView)
        {
            string detail = null;

            var detailsList = BillsDetailList.FindAll(s => s.BillID == dataGridView.CurrentRow.Cells[0].Value.ToString());

            for (int i = 0; i < detailsList.Count; i++)
            {
                detail += string.Format("Product ID: {0}\nCount: {1}\nPrice: {2}\nSum: {3}\n\n",
                    detailsList[i].ProductID, detailsList[i].Count, detailsList[i].Price, detailsList[i].Sum);
            }

            return detail;
        }
    }
}
