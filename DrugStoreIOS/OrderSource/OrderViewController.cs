// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace DrugStoreIOS
{
	public partial class OrderViewController : UITableViewController
	{
        private OrderController orders;

		public OrderViewController (IntPtr handle) : base (handle)
		{
		}

        public async override void ViewDidLoad()
		{
            try
            {
                orders = await OrderController.GetInstance();
                OrdersSource source = new OrdersSource(orders.ListOfOrders);
                OrderTableView.Source = source;
                OrderTableView.ReloadData();
                ActivityIndicator.StopAnimating();
                this.RefreshControl = new UIRefreshControl();
                this.RefreshControl.ValueChanged += (sender, e) =>
                {
                    this.RefreshControl.BeginRefreshing();
                    OrderTableView.ReloadData();
                    this.RefreshControl.EndRefreshing();
                };
            }
            catch
            {
                ActivityIndicator.StopAnimating();
                PresentViewController(GetAlertsClass.GetAlert("Не удалось подключиться к серверу"), true, null);
            }
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
            base.PrepareForSegue(segue, sender);
            var sourceController = segue.DestinationViewController as GoodsItemController;
            sourceController.item = orders.ListOfOrders[OrderTableView.IndexPathForSelectedRow.Row];
		}
	}
}
