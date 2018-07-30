using System;
using System.Collections.Generic;

using AppKit;
namespace DrugStore
{
    public class CatalogueSource : NSTableViewDataSource
    {
        public List<CatalogueItem> data;
        
        public CatalogueSource(List<CatalogueItem> data)
        {
            this.data = data;
        }

        public override nint GetRowCount(NSTableView tableView)
        {
            return data.Count;
        }
    }
}
