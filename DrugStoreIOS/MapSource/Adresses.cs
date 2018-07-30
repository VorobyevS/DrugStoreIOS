using System;
using Newtonsoft.Json;

namespace DrugStoreIOS
{
    public class Adresses
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Adress")]
        public string Adress { get; set; }

        [JsonProperty(PropertyName = "Xvalue")]
        public float Xvalue { get; set; }

        [JsonProperty(PropertyName = "Yvalue")]
        public float Yvalue { get; set; }

        [JsonProperty(PropertyName = "Available")]
        public bool Available { get; set; }
    }
}
