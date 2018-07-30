using System;
using Newtonsoft.Json;

namespace DrugStoreIOS
{
    public class Goods
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Brand")]
        public string Brand { get; set; }

        [JsonProperty(PropertyName = "Price")]
        public int Price { get; set; }

        [JsonProperty(PropertyName = "Available")]
        public int Available { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "Picture")]
        public Image Picture { get; set; }

        public class Image
        {
            [JsonProperty(PropertyName = "data")]
            public byte[] Pic { get; set; }
        }
    }
}
