using FruitStoreManager.Events;
using FruitStoreManager.Functions;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FruitStoreManager.Models
{
    class Item
    {
        public static readonly List<BillDetail> DetailList = new List<BillDetail>();

        public static void Add(DataGridView dataGridView, NumericUpDown numericUpDown)
        {
            var currentRow = dataGridView.CurrentRow;
            // tính thành tiền cho item được thêm vào giỏ
            var sum = numericUpDown.Value * decimal.Parse(currentRow.Cells["Price"].Value?.ToString());
            // tìm item có trong giỏ theo ID
            var value = DetailList.Find(s => s.ProductID.ToString() == currentRow.Cells["ID"].Value?.ToString());

            if (value != null) // nếu item đã có trong giỏ
            {
                Warning.ExistItem();
                return;
            }

            var detail = new BillDetail()
            {
                BillID = Display.BillList.Count + 1,
                ProductID = currentRow.Cells["ID"].Value,
                ProductName = currentRow.Cells["Name"].Value,
                Price = currentRow.Cells["Price"].Value,
                Count = numericUpDown.Value,
                Sum = (int)sum
            };

            DetailList.Add(detail);

            // trừ đi số hàng còn trong kho
            Display.ProductList.Where(s => s.ID.ToString() == dataGridView.CurrentRow.Cells["ID"].Value.ToString()).ToList()
                .ForEach(s => s.Quantity = decimal.Parse(s.Quantity.ToString()) - numericUpDown.Value);
            // hiển thị lại số lượng trong kho
            dataGridView.DataSource = Display.ProductList;
        }

        public static void Edit(DataGridView dataGridView, NumericUpDown numericUpDown)
        {
            // lấy số lượng của item trong giỏ
            var count = DetailList.Find(s => s.ProductID == dataGridView.CurrentRow.Cells["ID"].Value).Count;
            // sửa lại số lượng theo đúng yêu cầu
            DetailList.Where(s => s.ProductID == dataGridView.CurrentRow.Cells["ID"].Value).ToList().ForEach(s => s.Count = (double)numericUpDown.Value);
            // sửa lại số lượng item trong kho
            Display.ProductList.Where(s => s.ID.ToString() == dataGridView.CurrentRow.Cells["ID"].Value.ToString()).ToList()
                .ForEach(s => s.Quantity = (decimal)s.Quantity + (decimal)count - numericUpDown.Value);
            // hiển thị lại số lượng lên bảng
            dataGridView.DataSource = Display.ProductList;
        }

        public static void Detele(DataGridView dataGridView)
        {
            // lấy số lượng của item trong giỏ
            var count = DetailList.Find(s => s.ProductID == dataGridView.CurrentRow.Cells["ID"].Value).Count;
            // xóa item trong giỏ theo ID
            DetailList.Remove(DetailList.Find(s => s.ProductID.ToString() == dataGridView.CurrentRow.Cells["ID"].Value.ToString()));
            // thêm lại số item vào trong kho
            Display.ProductList.Where(s => s.ID.ToString() == dataGridView.CurrentRow.Cells["ID"].Value.ToString()).ToList()
                .ForEach(s => s.Quantity = (decimal)s.Quantity + (decimal)count);
            // hiển thị lại số lượng lên bảng
            dataGridView.DataSource = Display.ProductList;
        }
    }
}