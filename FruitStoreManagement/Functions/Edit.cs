using FruitStoreManager.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    class Edit
    {
        public static void Quantity()
        {
            var oldData = File.ReadAllText(Execute.GetFilePath("product")).Trim();

            dynamic jsonObj = JsonConvert.DeserializeObject(oldData);

            foreach (var item in List.Cart)
            {
                jsonObj["product"][int.Parse(item.ProductID.ToString())]["Quantity"] -= item.Count;
            }

            string newData = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(Execute.GetFilePath("product"), newData);
        }

        public static void Cart(DataGridView dataGridView, NumericUpDown numericUpDown)
        {
            // lấy số lượng của item trong giỏ
            var count = List.Cart.Find(s => s.ProductID == dataGridView.CurrentRow.Cells["ID"].Value).Count;
            // sửa lại số lượng theo đúng yêu cầu
            List.Cart.Where(s => s.ProductID == dataGridView.CurrentRow.Cells["ID"].Value).ToList().ForEach(s => s.Count = (double)numericUpDown.Value);
            // sửa lại số lượng item trong kho
            BindingList.Product.Where(s => s.ID.ToString() == dataGridView.CurrentRow.Cells["ID"].Value.ToString()).ToList()
                .ForEach(s => s.Quantity = double.Parse(s.Quantity.ToString()) + double.Parse(count.ToString()) - double.Parse(numericUpDown.Value.ToString()));
            // hiển thị lại số lượng lên bảng
            dataGridView.DataSource = BindingList.Product;
        }

        public static void Data(MainElement main, string fileName)
        {
            var oldData = File.ReadAllText(Execute.GetFilePath(fileName)).Trim();

            dynamic jsonObj = JsonConvert.DeserializeObject(oldData);
            jsonObj[fileName][main.DataGridView.CurrentRow.Index][main.DataGridView.CurrentCell.OwningColumn.Name] = main.DataGridView.CurrentCell.Value?.ToString();

            string newData = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(Execute.GetFilePath(fileName), newData);
        }
    }
}
