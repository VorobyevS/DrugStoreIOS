// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DrugStore
{
	[Register ("OrderViewControler")]
	partial class OrderViewControler
	{
		[Outlet]
		AppKit.NSButton DeleteButton { get; set; }

		[Outlet]
		AppKit.NSTableView OrderView { get; set; }

		[Outlet]
		AppKit.NSButton RefreshButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (RefreshButton != null) {
				RefreshButton.Dispose ();
				RefreshButton = null;
			}

			if (DeleteButton != null) {
				DeleteButton.Dispose ();
				DeleteButton = null;
			}

			if (OrderView != null) {
				OrderView.Dispose ();
				OrderView = null;
			}
		}
	}
}
