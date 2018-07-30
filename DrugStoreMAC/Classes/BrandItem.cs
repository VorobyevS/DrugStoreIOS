using System;
namespace DrugStore
{
    public class BrandItem
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public BrandItem(string name, string Country)
        {
            this.Name = name;
            this.Country = Country;
        }

        public BrandItem() { }
    }
}
