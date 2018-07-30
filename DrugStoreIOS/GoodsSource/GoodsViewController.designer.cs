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
	[Register ("GoodsViewController")]
	partial class GoodsViewController
	{
		[Outlet]
		UIKit.UIActivityIndicatorView ActivityIndicator { get; set; }

		[Outlet]
		UIKit.UISearchBar DrugSearchBar { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UITableView GoodsTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ActivityIndicator != null) {
				ActivityIndicator.Dispose ();
				ActivityIndicator = null;
			}

			if (GoodsTableView != null) {
				GoodsTableView.Dispose ();
				GoodsTableView = null;
			}

			if (DrugSearchBar != null) {
				DrugSearchBar.Dispose ();
				DrugSearchBar = null;
			}
		}
	}
}
