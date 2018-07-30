using System;
using System.Collections.Generic;

using AppKit;
namespace DrugStore
{
    public class BrandDelegate : NSTableViewDelegate
    {
        private const string CellIdentifier = "BrandCell";
        private BrandSource DataSource;

        public BrandDelegate(BrandSource source)
        {
            this.DataSource = source;
        }

        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            NSTextField view = (NSTextField)tableView.MakeView(CellIdentifier, this);
            if (view == null)
            {
                view = new NSTextField();
                view.Identifier = CellIdentifier;
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = true;
                view.Editable = false;
                view.Alignment = NSTextAlignment.Center;
            }

            switch (tableColumn.Title)
            {
                case "Имя брэнда":
                    view.StringValue = DataSource.data[(int)row].Name;
                    break;
                case "Страна":
                    view.StringValue = DataSource.data[(int)row].Country;
                    break;
            }

            return view;
        }
    }
}
