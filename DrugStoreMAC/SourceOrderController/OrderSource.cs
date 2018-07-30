using System;
using System.Collections.Generic;

using AppKit;
namespace DrugStore
{
    public class OrderSource :NSTableViewDataSource
    {
        public List<OrderItem> data;

        public OrderSource(List<OrderItem> data)
        {
            this.data = data;
        }

        public override nint GetRowCount(NSTableView tableView)
        {
            return data.Count;
        }
    }
}
