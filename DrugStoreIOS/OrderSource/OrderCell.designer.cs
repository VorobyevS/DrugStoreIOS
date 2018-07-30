// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DrugStoreIOS
{
	[Register ("OrderCell")]
	partial class OrderCell
	{
		[Outlet]
		UIKit.UILabel NameLabel { get; set; }

		[Outlet]
		UIKit.UIImageView OrderImage { get; set; }

		[Outlet]
		UIKit.UILabel StatusLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (NameLabel != null) {
				NameLabel.Dispose ();
				NameLabel = null;
			}

			if (StatusLabel != null) {
				StatusLabel.Dispose ();
				StatusLabel = null;
			}

			if (OrderImage != null) {
				OrderImage.Dispose ();
				OrderImage = null;
			}
		}
	}
}
