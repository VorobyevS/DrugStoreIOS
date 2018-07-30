using System;
using System.Linq;

using Foundation;
using System.Collections.Generic;
using UIKit;

namespace DrugStoreIOS
{
	public partial class GoodsItemController : UIViewController
	{
        public Goods item { get; set; }
        private OrderController orders;
        private List<OrderItem> itemOrder;

		public GoodsItemController (IntPtr handle) : base (handle)
		{
		}

        public override async void ViewDidLoad()
		{
            try
            {
                UIBarButtonItem GoToMapBarItem = new UIBarButtonItem();
                GoToMapBarItem.Image = UIImage.FromBundle("Map");
                GoToMapBarItem.Clicked += (sender, e) => 
                {
                    PerformSegue("MapSegue", this);
                };
                this.NavigationItem.SetRightBarButtonItem(GoToMapBarItem, true);
                this.orders = await OrderController.GetInstance();
                itemOrder = (from i in orders.ListOfOrders where i.Name == item.Name select i).ToList();
                AddButton.TouchUpInside += async (sender, e) => 
                {
                    AddButton.Enabled = false;
                    CountStepper.Enabled = false;
                    this.AddButton.BackgroundColor = UIColor.Red;
                    this.DrugAvailabilityImage.Image = UIImage.FromBundle("Sending");

                    if (itemOrder.Count == 0)
                    {
                        await orders.AddOrder(new Orders(AppDelegate.UserName, item.Name, false, (int)CountStepper.Value));
                        orders.ListOfOrders.Add(new OrderItem(item){Derived = false});
                        PresentViewController(GetAlertsClass.GetAlertForOrder("Ожидайте заказа"), true, null);
                    }
                    else
                    {
                        await orders.UpdateOrder(new Orders(AppDelegate.UserName, item.Name, false, (int)CountStepper.Value));
                        itemOrder[0].Derived = false;
                        PresentViewController(GetAlertsClass.GetAlertForOrder("Ожидайте заказа"), true, null);
                    }
                };

                CountStepper.ValueChanged += (object sender, EventArgs e) => 
                {
                    this.DrugCountLabel.Text = (int)((UIStepper)sender).Value + " шт.";
                    this.DrugPriceLabel.Text = ((int)((UIStepper)sender).Value * item.Price) + " BYR";
                };

                InitInputs();
            }
            catch
            {
                PresentViewController(GetAlertsClass.GetAlert("Не удалось подключиться к серверу"), true, null);
            }
		}

		private void InitInputs()
        {
            this.DrugNameLabel.Text = item.Name;
            this.DrugBrandLabel.Text = item.Brand;
            this.DrugPriceLabel.Text = ((int)CountStepper.Value * item.Price) + " BYR";
            this.DrugImage.Image = UIImage.LoadFromData(NSData.FromArray(item.Picture.Pic));
            this.CountStepper.MaximumValue = item.Available;
            this.DrugCountLabel.Text = this.CountStepper.Value.ToString() + " шт.";
            if (itemOrder.Count() == 1)
            {
                this.CountStepper.Value = itemOrder[0].Count;
                this.DrugCountLabel.Text = this.CountStepper.Value.ToString() + " шт.";
                this.DrugPriceLabel.Text = ((int)CountStepper.Value * item.Price) + " BYR";

                if (itemOrder[0].Derived)
                {
                    this.DrugAvailabilityImage.Image = UIImage.FromBundle("Arrived");
                    if(item.Available<=0)
                        this.AddButton.BackgroundColor = UIColor.Red;
                    this.DrugPriceLabel.TextColor = UIColor.Green;
                }
                else
                {
                    this.DrugAvailabilityImage.Image = UIImage.FromBundle("Sending");
                    this.CountStepper.Enabled = false;
                    this.AddButton.BackgroundColor = UIColor.Red;
                    this.AddButton.Enabled = false;
                    this.DrugPriceLabel.TextColor = UIColor.Green;
                }
            }
            else if (item.Available>0)
            {
                this.DrugAvailabilityImage.Image = UIImage.FromBundle("AvailableImage");
                this.DrugPriceLabel.TextColor = UIColor.Green;
            }
            else
            {
                this.DrugAvailabilityImage.Image = UIImage.FromBundle("NotAvailableImage");
                this.CountStepper.Enabled = false;
                this.AddButton.Enabled = false;
                this.DrugPriceLabel.TextColor = UIColor.Red;
                this.AddButton.BackgroundColor = UIColor.Red;
            }
            this.DrugDescriptionLabel.Text = item.Description;
            this.DrugDescriptionLabel.SizeToFit();
        }

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
            if(segue.Identifier.Equals("MapSegue"))
            {
                (segue.DestinationViewController as MapViewController).Drugname = item.Name;
            }
		}
	}
}
