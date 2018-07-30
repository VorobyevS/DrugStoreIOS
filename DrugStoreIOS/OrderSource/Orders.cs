using System;
using Newtonsoft.Json;

namespace DrugStoreIOS
{
    public class Orders
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "CustomerName")]
        public string CustomerName { get; set; }

        [JsonProperty(PropertyName = "DrugName")]
        public string DrugName { get; set; }

        [JsonProperty(PropertyName = "Derived")]
        public bool Derived { get; set; }

        [JsonProperty(PropertyName = "Count")]
        public int Count { get; set; }

        public Orders(string CustomerName, string Drug, bool derived, int Count)
        {
            this.CustomerName = CustomerName;
            this.DrugName = Drug;
            this.Derived = derived;
            this.Count = Count;
        }
    }
}
