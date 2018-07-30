using System;
using System.Collections.Generic;

using AppKit;
namespace DrugStore
{
    public class OrderDelegate : NSTableViewDelegate
    {
        private const string CellIdentifier = "OrderCell";
        private OrderSource DataSource;

        public OrderDelegate(OrderSource source)
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
                case "Номер телефона":
                    view.StringValue = DataSource.data[(int)row].PhoneNumber;
                    break;
                case "Заказчик":
                    view.StringValue = DataSource.data[(int)row].CustomerName;
                    break;
                case "Препарат":
                    view.StringValue = DataSource.data[(int)row].DrugName;
                    break;
                case "Адрес":
                    view.StringValue = DataSource.data[(int)row].Adress;
                    break;
                case "Количество":
                    view.IntValue = DataSource.data[(int)row].Count;
                    break;
            }

            return view;
        }
    }
}
