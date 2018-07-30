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
	[Register ("BrandViewController")]
	partial class BrandViewController
	{
		[Outlet]
		AppKit.NSTableView BrandTable { get; set; }

		[Outlet]
		AppKit.NSButton DeleteButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BrandTable != null) {
				BrandTable.Dispose ();
				BrandTable = null;
			}

			if (DeleteButton != null) {
				DeleteButton.Dispose ();
				DeleteButton = null;
			}
		}
	}
}
