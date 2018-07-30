using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
namespace DrugStoreIOS
{
    public class OrdersSource : UITableViewSource
    {
        private List<OrderItem> data;
        private string CellIdentifier = "OrderCell";

        public OrdersSource(List<OrderItem> data)
        {
            this.data = data;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return data.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            OrderCell cell = tableView.DequeueReusableCell(CellIdentifier) as OrderCell;
            cell.UpdateCell(data[indexPath.Row]);
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, false);
        }


    }
}
