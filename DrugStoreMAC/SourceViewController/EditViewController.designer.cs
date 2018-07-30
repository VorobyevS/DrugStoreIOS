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
	[Register ("EditViewController")]
	partial class EditViewController
	{
		[Outlet]
		AppKit.NSTextField AvailableField { get; set; }

		[Outlet]
		AppKit.NSTextField BrandField { get; set; }

		[Outlet]
		AppKit.NSButton CancelButton { get; set; }

		[Outlet]
		AppKit.NSTextView Desc { get; set; }

		[Outlet]
		AppKit.NSScrollView DescriptionView { get; set; }

		[Outlet]
		AppKit.NSButton EditedButton { get; set; }

		[Outlet]
		AppKit.NSImageView Imageview { get; set; }

		[Outlet]
		AppKit.NSTextField NameField { get; set; }

		[Outlet]
		AppKit.NSTextField PriceField { get; set; }

		[Outlet]
		AppKit.NSButton UploadButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
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

			if (Desc != null) {
				Desc.Dispose ();
				Desc = null;
			}

			if (DescriptionView != null) {
				DescriptionView.Dispose ();
				DescriptionView = null;
			}

			if (EditedButton != null) {
				EditedButton.Dispose ();
				EditedButton = null;
			}

			if (Imageview != null) {
				Imageview.Dispose ();
				Imageview = null;
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
