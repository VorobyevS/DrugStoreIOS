// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Threading.Tasks;

using Foundation;
using UIKit;

namespace DrugStoreIOS
{
	public partial class GoodsCell : UITableViewCell
	{
		public GoodsCell (IntPtr handle) : base (handle)
		{
		}

        public void UpdateCell(Goods item)
        {
            this.MainLabel.Text = item.Name;
            this.SubtitleLabel.Text = item.Brand;
            this.ImageItem.Image = UIImage.LoadFromData(NSData.FromArray(item.Picture.Pic));
        }

	}
}
