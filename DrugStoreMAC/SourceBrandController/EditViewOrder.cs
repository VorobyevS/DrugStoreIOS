// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Text.RegularExpressions;

using Foundation;
using AppKit;

namespace DrugStore
{
	public partial class EditViewOrder : NSViewController
	{
        public BrandItem item = new BrandItem();
        public event EventHandler added;

		public EditViewOrder (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CancelButton.Activated+= (sender, e) => DismissViewController(this);

            AddButton.Activated+= (sender, e) => 
            {
                if (CheckExpressinn())
                {
                    item.Name = BrandName.StringValue;
                    item.Country = CountryField.StringValue;
                    added(this, new EventArgs());
                    DismissViewController(this);
                }
                else
                    (SqlClass.GetError("Поля введены не верно")).RunModal();
            };
        }

        private bool CheckExpressinn()
        {
            return (Regex.IsMatch(BrandName.StringValue, @"^\w+$") && Regex.IsMatch(CountryField.StringValue, @"^\w+$"));
        }
	}
}
