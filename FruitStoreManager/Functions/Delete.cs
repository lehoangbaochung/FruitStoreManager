using FruitStoreManager.Models;
using System.Linq;
using System.Windows.Forms;

namespace FruitStoreManager.Functions
{
    class Delete
    {
        public static void Item(DataGridView dataGridView)
        {
            // lấy số lượng của item trong giỏ
            var count = List.Cart.Find(s => s.ProductID == dataGridView.CurrentRow.Cells["ID"].Value).Count;
            // xóa item trong giỏ theo ID
            List.Cart.Remove(List.Cart.Find(s => s.ProductID.ToString() == dataGridView.CurrentRow.Cells["ID"].Value.ToString()));
            // thêm lại số item vào trong kho
            BindingList.Product.Where(s => s.ID.ToString() == dataGridView.CurrentRow.Cells["ID"].Value.ToString()).ToList()
                .ForEach(s => s.Quantity = (decimal)s.Quantity + (decimal)count);
            // hiển thị lại số lượng lên bảng
            dataGridView.DataSource = BindingList.Product;
        }
    }
}
