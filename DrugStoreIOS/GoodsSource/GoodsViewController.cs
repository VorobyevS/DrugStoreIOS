using Foundation;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using UIKit;

namespace DrugStoreIOS
{
    public partial class GoodsViewController : UITableViewController
    {
        private GoodsController goods = GoodsController.GetInstance();
        private bool isAsyncUpdateAlowed = true;
        private GoodsSource source;

        public GoodsViewController (IntPtr handle) : base (handle)
        {
        }

        public override async void ViewDidLoad()
		{
            try
            {
                await goods.GetNext();
                await OrderController.GetInstance();
                source = new GoodsSource(goods.List);
                source.RemoveKeyboard += Source_RemoveKeyboard;
                GoodsTableView.Source = source;
                GoodsTableView.ReloadData();
                ActivityIndicator.StopAnimating();
                this.source.UploadNextItems += async (s, e) =>
                {
                    if (isAsyncUpdateAlowed)
                    {
                        isAsyncUpdateAlowed = false;
                        ActivityIndicator.StartAnimating();

                        if (await goods.GetNext())
                            GoodsTableView.ReloadData();

                        ActivityIndicator.StopAnimating();

                        isAsyncUpdateAlowed = true;
                    }
                };

                this.DrugSearchBar.SearchButtonClicked += async (object sender, EventArgs e) =>
                {
                       
                    ActivityIndicator.StartAnimating();
                    this.DrugSearchBar.ResignFirstResponder();
                    List<Goods> search = await goods.Search((sender as UISearchBar).Text);
                    ActivityIndicator.StopAnimating();
                    GoodsSource sou = new GoodsSource(search);
                    sou.RemoveKeyboard += Source_RemoveKeyboard;
                    GoodsTableView.Source = sou;
                    GoodsTableView.ReloadData();
                };

                this.DrugSearchBar.TextChanged += (object sender, UISearchBarTextChangedEventArgs e) => 
                {
                    if (String.IsNullOrWhiteSpace(e.SearchText))
                    {
                        this.DrugSearchBar.ResignFirstResponder();
                        GoodsTableView.Source = source;
                        GoodsTableView.ReloadData();
                    }
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
            this.DrugSearchBar.ResignFirstResponder();
            var sourceController = segue.DestinationViewController as GoodsItemController;
            sourceController.item = goods.List[GoodsTableView.IndexPathForSelectedRow.Row];
		}

        void Source_RemoveKeyboard(object sender, EventArgs e)
        {
            this.DrugSearchBar.ResignFirstResponder();
        }

    }
}
