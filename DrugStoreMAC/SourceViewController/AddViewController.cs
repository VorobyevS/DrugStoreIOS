// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Text.RegularExpressions;
using System.IO;

using AppKit;

namespace DrugStore
{
	public partial class AddViewController : NSViewController
	{
        public CatalogueItem item;
        public event EventHandler addOne;

		public AddViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            item = new CatalogueItem();

            CancelButton.Activated += (sender, e) => DismissController(this);

            AddButton.Activated += (sender, e) => 
            {
                if (CheckExpressions())
                {
                    item.Name = NameField.StringValue;
                    item.Brand = BrandField.StringValue;
                    item.Price = PriceField.IntValue;
                    item.Available = AvailableField.IntValue;
                    item.Description = DescriptionField.Value;

                    //обращение к базе данных на добавление элемента
                    try
                    {
                        SqlClass.AddItemToBase(item);
                        addOne(this, new EventArgs());
                        DismissViewController(this);
                    }
                    catch
                    {
                        (SqlClass.GetError("Не удалось добавить в БД")).RunModal();
                    }

                }
                else
                    (SqlClass.GetError("Поля введены не верно")).RunModal();
            };

            UploadButton.Activated+= (sender, e) => 
            {
                NSOpenPanel openpanel = new NSOpenPanel();
                openpanel.AllowedFileTypes = new string[] { @"jpg" };
                openpanel.RunModal();
                ImageView.Image = new NSImage(openpanel.Url);
                if(openpanel.Url.Path !=null)
                    item.Image = File.ReadAllBytes(openpanel.Url.Path);
            };
        }

        private bool CheckExpressions()
        {
            return (Regex.IsMatch(NameField.StringValue, @"^\w{1,20}") && Regex.IsMatch(BrandField.StringValue, @"^\w{1,20}") && Regex.IsMatch(PriceField.StringValue, @"^\d+$") && Regex.IsMatch(AvailableField.StringValue, @"^\d+$"));
        }
	}
}
