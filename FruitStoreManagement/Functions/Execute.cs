using FruitStoreManager.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    class Execute
    {
        public static string GetFilePath(string filename)
        {
            return Path.Combine(Environment.CurrentDirectory, @"Data\" + filename + ".json");
        }

        public static dynamic Read(string fileName)
        {
            using StreamReader sr = File.OpenText(GetFilePath(fileName));
            var json = sr.ReadToEnd();
            dynamic array = JsonConvert.DeserializeObject(json);
            return array;
        }

        public static void Insert(MainElement main)
        {
            switch (main.TabControl.SelectedTab.Text)
            {
                case "Account":
                    Add.Account(main.DataGridView);
                    break;
                case "Bill":
                    Add.Bill(main.DataGridView);
                    break;
                case "Customer":
                    Add.Customer(main.DataGridView);
                    break;
                case "Employee":
                    Add.Employee(main.DataGridView);
                    break;
                case "Product":
                    Add.Product(main.DataGridView);
                    break;
            }    
        }

        public static void Update(MainElement main)
        {
            switch (main.TabControl.SelectedTab.Text)
            {
                case "Account":
                    Edit.Data(main, "account");
                    break;
                case "Bill":
                    Edit.Data(main, "bill");
                    break;
                case "Customer":
                    Edit.Data(main, "customer");
                    break;
                case "Employee":
                    Edit.Data(main, "employee");
                    break;
                case "Product":
                    Edit.Data(main, "product");
                    break;
            }
        }

        public static void Delete(DataGridView dataGridView, string fileName)
        {
            var oldData = File.ReadAllText(GetFilePath(fileName));

            dynamic jsonObj = JsonConvert.DeserializeObject(oldData);
            jsonObj[fileName][dataGridView.CurrentRow.Index][dataGridView.CurrentRow.Cells[0].OwningColumn.Name] = null;

            string newData = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(GetFilePath(fileName), newData);
        }
    }
}
