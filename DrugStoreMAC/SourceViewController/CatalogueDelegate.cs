using System;

using AppKit;
namespace DrugStore
{
    public class CatalogueDelegate : NSTableViewDelegate
    {
        private const string CellIdentifier = "CatalogueCell";
        private CatalogueSource DataSource;

        public CatalogueDelegate(CatalogueSource dat)
        {
            DataSource = dat;
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
                case "Название":
                    view.StringValue = DataSource.data[(int)row].Name;
                    break;
                case "Цена":
                    view.IntValue = DataSource.data[(int)row].Price;
                    break;
                case "Наличие":
                    view.IntValue = DataSource.data[(int)row].Available;
                    break;
            }

            return view;
        }


    }
}
