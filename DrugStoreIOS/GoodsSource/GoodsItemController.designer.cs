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
	[Register ("GoodsItemController")]
	partial class GoodsItemController
	{
		[Outlet]
		UIKit.UIButton AddButton { get; set; }

		[Outlet]
		UIKit.UIStepper CountStepper { get; set; }

		[Outlet]
		UIKit.UIImageView DrugAvailabilityImage { get; set; }

		[Outlet]
		UIKit.UILabel DrugBrandLabel { get; set; }

		[Outlet]
		UIKit.UILabel DrugCountLabel { get; set; }

		[Outlet]
		UIKit.UILabel DrugDescriptionLabel { get; set; }

		[Outlet]
		UIKit.UIImageView DrugImage { get; set; }

		[Outlet]
		UIKit.UILabel DrugNameLabel { get; set; }

		[Outlet]
		UIKit.UILabel DrugPriceLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AddButton != null) {
				AddButton.Dispose ();
				AddButton = null;
			}

			if (DrugAvailabilityImage != null) {
				DrugAvailabilityImage.Dispose ();
				DrugAvailabilityImage = null;
			}

			if (DrugBrandLabel != null) {
				DrugBrandLabel.Dispose ();
				DrugBrandLabel = null;
			}

			if (DrugDescriptionLabel != null) {
				DrugDescriptionLabel.Dispose ();
				DrugDescriptionLabel = null;
			}

			if (DrugImage != null) {
				DrugImage.Dispose ();
				DrugImage = null;
			}

			if (DrugNameLabel != null) {
				DrugNameLabel.Dispose ();
				DrugNameLabel = null;
			}

			if (DrugPriceLabel != null) {
				DrugPriceLabel.Dispose ();
				DrugPriceLabel = null;
			}

			if (DrugCountLabel != null) {
				DrugCountLabel.Dispose ();
				DrugCountLabel = null;
			}

			if (CountStepper != null) {
				CountStepper.Dispose ();
				CountStepper = null;
			}
		}
	}
}
