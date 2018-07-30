// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace DrugStoreIOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView ActivityIndicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LogInButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField LoginField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PasswordField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton RegistrationButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ActivityIndicator != null) {
                ActivityIndicator.Dispose ();
                ActivityIndicator = null;
            }

            if (LogInButton != null) {
                LogInButton.Dispose ();
                LogInButton = null;
            }

            if (LoginField != null) {
                LoginField.Dispose ();
                LoginField = null;
            }

            if (PasswordField != null) {
                PasswordField.Dispose ();
                PasswordField = null;
            }

            if (RegistrationButton != null) {
                RegistrationButton.Dispose ();
                RegistrationButton = null;
            }
        }
    }
}