﻿using FruitStoreManager.Models;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    internal class Execute
    {
        private static readonly string FolderPath = Directory.CreateDirectory(@"D:\FruitStoreManager\Resources").FullName;

        public static string GetFilePath(string fileName)
        {
            return FolderPath + @"\" + fileName + ".json";
        }

        public static void CreateFiles()
        {
            var filesName = new string[] { "account", "bill", "billdetail", "customer", "employee", "product", "request", "statistic" };

            foreach (var item in filesName)
            {
                var path = FolderPath + @"\" + item + ".json";

                if (!File.Exists(path))
                {
                    File.Create(path).Close();

                    if (item == "account")
                    {
                        TextWriter tw = new StreamWriter(path);
                        tw.WriteLine("{\"" + item + "\":[{\"ID\":\"admin\",\"Password\":\"admin\",\"Permission\":\"Quản lý\"}]}");
                        tw.Close();
                    }
                    else if (item == "request")
                    {
                        TextWriter tw = new StreamWriter(path);
                        tw.WriteLine("{\"" + item + "\": [{\"EmployeeID\":null,\"Title\":\"Sửa thông tin\",\"Content\":null,\"Time\":null,\"Status\":null},{\"" +
                            "\"EmployeeID\":null,\"Title\":\"Chấm công\",\"Content\":null,\"Time\":null,\"Status\":null},{\"EmployeeID\": null,\"Title\":\"Nghỉ việc\"" +
                            ",\"Content\":null,\"Time\":null,\"Status\":null}]}");
                        tw.Close();
                    }    
                    else
                    {
                        TextWriter tw = new StreamWriter(path);
                        tw.WriteLine("{\"" + item + "\": []}");
                        tw.Close();
                    }    
                }
            }
        }

        public static dynamic Read(string fileName)
        {
            using var sr = File.OpenText(GetFilePath(fileName));
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
