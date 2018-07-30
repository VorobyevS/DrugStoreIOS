using System;
using Newtonsoft.Json;

namespace DrugStoreIOS
{
    public class OrderItem : Goods
    {
        [JsonProperty(PropertyName = "Derived")]
        public bool Derived { get; set; }

        [JsonProperty(PropertyName = "Count")]
        public int Count { get; set; }

        public OrderItem() { }

        public OrderItem (Goods item)
        {
            this.Name = item.Name;
            this.Brand = item.Brand;
            this.Price = item.Price;
            this.Picture = item.Picture;
            this.Description = item.Description;
            this.Available = item.Available;
            this.Derived = false;
        }
    }
}
