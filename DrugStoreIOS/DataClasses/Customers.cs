using System;
using Newtonsoft.Json;

namespace DrugStoreIOS
{
    public class Customers
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Adress")]
        public string Adress { get; set; }

        [JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
