using System.Collections.Generic;
using System.ComponentModel;

namespace FruitStoreManager.Models
{
    class List
    {
        public static readonly List<BillDetail> BillDetail = new List<BillDetail>();
        public static readonly List<BillDetail> Cart = new List<BillDetail>();
    }

    class BindingList
    {
        public static readonly BindingList<Account> Account = new BindingList<Account>();
        public static readonly BindingList<Bill> Bill = new BindingList<Bill>();
        public static readonly BindingList<Customer> Customer = new BindingList<Customer>();
        public static readonly BindingList<Employee> Employee = new BindingList<Employee>();
        public static readonly BindingList<Product> Product = new BindingList<Product>();
        public static readonly BindingList<Request> Request = new BindingList<Request>();
        public static readonly BindingList<Statistic> Statistic = new BindingList<Statistic>();
    }
}
