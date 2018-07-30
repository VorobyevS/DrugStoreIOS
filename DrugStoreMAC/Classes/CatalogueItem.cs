using System;
namespace DrugStore
{
    public class CatalogueItem
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public int Available { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public CatalogueItem(string name, string brand, int price, int available, string description, byte[] image)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Available = available;
            this.Description = description;
            this.Image = image;
        }

        public CatalogueItem(){}
    }
}
