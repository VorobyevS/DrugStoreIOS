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
	[Register ("OrderViewController")]
	partial class OrderViewController
	{
		[Outlet]
		UIKit.UIActivityIndicatorView ActivityIndicator { get; set; }

		[Outlet]
		UIKit.UITableView OrderTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (OrderTableView != null) {
				OrderTableView.Dispose ();
				OrderTableView = null;
			}

			if (ActivityIndicator != null) {
				ActivityIndicator.Dispose ();
				ActivityIndicator = null;
			}
		}
	}
}
