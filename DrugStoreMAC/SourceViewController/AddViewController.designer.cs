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
	[Register ("AddViewController")]
	partial class AddViewController
	{
		[Outlet]
		AppKit.NSButton AddButton { get; set; }

		[Outlet]
		AppKit.NSTextField AvailableField { get; set; }

		[Outlet]
		AppKit.NSTextField BrandField { get; set; }

		[Outlet]
		AppKit.NSButton CancelButton { get; set; }

		[Outlet]
		AppKit.NSTextView DescriptionField { get; set; }

		[Outlet]
		AppKit.NSImageView ImageView { get; set; }

		[Outlet]
		AppKit.NSTextField NameField { get; set; }

		[Outlet]
		AppKit.NSTextField PriceField { get; set; }

		[Outlet]
		AppKit.NSButton UploadButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AddButton != null) {
				AddButton.Dispose ();
				AddButton = null;
			}

			if (AvailableField != null) {
				AvailableField.Dispose ();
				AvailableField = null;
			}

			if (BrandField != null) {
				BrandField.Dispose ();
				BrandField = null;
			}

			if (CancelButton != null) {
				CancelButton.Dispose ();
				CancelButton = null;
			}

			if (DescriptionField != null) {
				DescriptionField.Dispose ();
				DescriptionField = null;
			}

			if (ImageView != null) {
				ImageView.Dispose ();
				ImageView = null;
			}

			if (NameField != null) {
				NameField.Dispose ();
				NameField = null;
			}

			if (PriceField != null) {
				PriceField.Dispose ();
				PriceField = null;
			}

			if (UploadButton != null) {
				UploadButton.Dispose ();
				UploadButton = null;
			}
		}
	}
}
