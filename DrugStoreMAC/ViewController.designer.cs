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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTableView CatalogTableView { get; set; }

		[Outlet]
		AppKit.NSTextField CountField { get; set; }

		[Outlet]
		AppKit.NSButton DeleteButton { get; set; }

		[Outlet]
		AppKit.NSButton EditButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CatalogTableView != null) {
				CatalogTableView.Dispose ();
				CatalogTableView = null;
			}

			if (CountField != null) {
				CountField.Dispose ();
				CountField = null;
			}

			if (DeleteButton != null) {
				DeleteButton.Dispose ();
				DeleteButton = null;
			}

			if (EditButton != null) {
				EditButton.Dispose ();
				EditButton = null;
			}
		}
	}
}
