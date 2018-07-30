using System;
using System.Collections.Generic;

using AppKit;
namespace DrugStore
{
    public class BrandSource : NSTableViewDataSource
    {
        public List<BrandItem> data;

        public BrandSource(List<BrandItem> data)
        {
            this.data = data;
        }

        public override nint GetRowCount(NSTableView tableView)
        {
            return data.Count;
        }
    }
}
