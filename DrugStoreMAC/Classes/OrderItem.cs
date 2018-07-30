using System;
namespace DrugStore
{
    public class OrderItem
    {
        public string CustomerName { get; set; }
        public string DrugName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public int Count { get; set; }

        public OrderItem(string customer, string drug, string adress, string phoneNumber, int count)
        {
            this.CustomerName = customer;
            this.DrugName = drug;
            this.Adress = adress;
            this.PhoneNumber = phoneNumber;
            this.Count = count;
        }

        public OrderItem() { }
    }
}
