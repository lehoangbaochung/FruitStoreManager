﻿using Newtonsoft.Json;
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

        public static void Edit(DataGridView dataGridView, string fileName)
        {
            var oldData = File.ReadAllText(GetFilePath(fileName)).Trim();

            dynamic jsonObj = JsonConvert.DeserializeObject(oldData);
            jsonObj[fileName][dataGridView.CurrentRow.Index][dataGridView.CurrentCell.OwningColumn.Name] = dataGridView.CurrentCell.Value?.ToString();

            string newData = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(GetFilePath(fileName), newData);
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