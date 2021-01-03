using System.Collections.Generic;

namespace FruitStoreManager.Models
{
    class Bill
    {
        public string ID { get; set; }
        public string CustomerID { get; set; }
        public string EmployeeID { get; set; }
        public string Total { get; set; }
        public string PaymentMethod { get; set; }
    }

    class BillDetail
    {
        public string BillID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Count { get; set; }
        public string Price { get; set; }
        public string Sum { get; set; }

        private string SumTotal()
        {
            return (int.Parse(Count) * double.Parse(Price)).ToString();
        }
    }
}
