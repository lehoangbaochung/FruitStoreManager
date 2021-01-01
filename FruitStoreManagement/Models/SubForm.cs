using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FruitStoreManager.Models
{
    class SubForm
    {
        public TextBox Search { get; set; }
        public DataGridView Table { get; set; }
        public int TableRowsCount { get; set; }
    }
}
