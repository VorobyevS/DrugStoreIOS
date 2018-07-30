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
	[Register ("EditViewOrder")]
	partial class EditViewOrder
	{
		[Outlet]
		AppKit.NSButton AddButton { get; set; }

		[Outlet]
		AppKit.NSTextField BrandName { get; set; }

		[Outlet]
		AppKit.NSButton CancelButton { get; set; }

		[Outlet]
		AppKit.NSTextField CountryField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BrandName != null) {
				BrandName.Dispose ();
				BrandName = null;
			}

			if (CountryField != null) {
				CountryField.Dispose ();
				CountryField = null;
			}

			if (AddButton != null) {
				AddButton.Dispose ();
				AddButton = null;
			}

			if (CancelButton != null) {
				CancelButton.Dispose ();
				CancelButton = null;
			}
		}
	}
}
