namespace FruitStoreManager.Models
{
    class Bill
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public int Sum { get; set; }
        public int Properties { get; set; }
        public string Address { get; set; }
        public int CustomerID { get; set; }
        public int StaffID { get; set; }
        public int BankID { get; set; }
        public int LogisticsID { get; set; }
    }
}
