using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
namespace DrugStoreIOS
{
    public class GoodsSource : UITableViewSource
    {
        public event EventHandler RemoveKeyboard;
        public event EventHandler UploadNextItems;
        private List<Goods> data;
        private string CellIdentifier = "GoodsCell";

        public GoodsSource(List<Goods> data)
        {
            this.data = data;
        }

		public override nint RowsInSection(UITableView tableview, nint section)
		{
            return data.Count;
		}

        public override  UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
            GoodsCell cell = tableView.DequeueReusableCell(CellIdentifier) as GoodsCell;
            cell.UpdateCell(data[indexPath.Row]);
            return cell;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
            tableView.DeselectRow(indexPath, false);
		}

        public override void Scrolled(UIScrollView scrollView)
		{
            if (RemoveKeyboard != null)
                RemoveKeyboard(this, new EventArgs());
            var height = scrollView.Frame.Size.Height;
            var contetOffset = scrollView.ContentOffset.Y;
            var distanceFromBottom = scrollView.ContentSize.Height - contetOffset-1.0;
            if (distanceFromBottom < height && UploadNextItems!=null)
                UploadNextItems(this, new EventArgs());
		}

	}
}
