using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    class DataManagement
    {
        public static dynamic Read(string filename)
        {
            using StreamReader sr = File.OpenText(Path.Combine(Environment.CurrentDirectory, filename));
            var json = sr.ReadToEnd();
            dynamic array = JsonConvert.DeserializeObject(json);
            return array;
        }

        public static void Edit(DataGridView dataGridView, string fileName)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, @"Data\" + fileName + ".json");
            var oldData = File.ReadAllText(filePath);

            dynamic jsonObj = JsonConvert.DeserializeObject(oldData);
            jsonObj[fileName][dataGridView.CurrentRow.Index][dataGridView.CurrentCell.OwningColumn.Name] = dataGridView.CurrentCell.Value?.ToString();

            string newData = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(filePath, newData);
        }

        public static void Delete(DataGridView dataGridView, string fileName)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, @"Data\" + fileName + ".json");
            var oldData = File.ReadAllText(filePath);

            dynamic jsonObj = JsonConvert.DeserializeObject(oldData);
            jsonObj[fileName][dataGridView.CurrentRow.Index][dataGridView.CurrentRow.Cells[0].OwningColumn.Name] = null;

            string newData = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(filePath, newData);
        }
    }
}
