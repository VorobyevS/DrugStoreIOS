using System;
using Foundation;
using UIKit;

namespace DrugStoreIOS
{
    public partial class ViewController : UIViewController
    {
        private NSObject _didShowNotificationObserver;
        private NSObject _willHideNotificationObserver;
        private UIView activeTextFieldView;
        private nfloat amountToScroll = 0.0f;
        private nfloat alreadyScrolledAmount = 0.0f;
        private nfloat bottomOfTheActiveTextField = 0.0f;
        private nfloat offsetBetweenKeybordAndTextField = 10.0f;
        private bool isMoveRequired = false;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            _didShowNotificationObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.DidShowNotification, KeyBoardDidShow, this);
                                                                 
            _willHideNotificationObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, KeyBoardWillHide, this);

            ActivityIndicator.StopAnimating();

            this.LoginField.ShouldReturn += (textField) => textField.ResignFirstResponder();
            this.PasswordField.ShouldReturn += (textField) => textField.ResignFirstResponder();

            this.View.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                LoginField.ResignFirstResponder();
                PasswordField.ResignFirstResponder();
            }));

            LogInButton.TouchUpInside += async (sender, e) => 
            {
                Customers registrationFieldsForAsync = new Customers() { Name = LoginField.Text, Password = PasswordField.Text };
                ActivityIndicator.StartAnimating();

                try
                {
                    LogInButton.Enabled = false;
                    RegistrationButton.Enabled = false;
                    LoginAndPasswordCheck.LoginCheck(registrationFieldsForAsync.Name);
                    LoginAndPasswordCheck.PasswordCheck(registrationFieldsForAsync.Password);
                    await UsersCheckClass.TryToLogIn(registrationFieldsForAsync);
                    AppDelegate.UserName = registrationFieldsForAsync.Name;
                    PerformSegue("LogInSegue", null);
                }
                catch (FiledsCheckException e1)
                {
                    ActivityIndicator.StopAnimating();
                    LogInButton.Enabled = true;
                    RegistrationButton.Enabled = true;
                    PresentViewController(GetAlertsClass.GetAlert(e1.Message), true, null);
                }
                catch (UserCheckClassException e1)
                {
                    ActivityIndicator.StopAnimating();
                    LogInButton.Enabled = true;
                    RegistrationButton.Enabled = true;
                    PresentViewController(GetAlertsClass.GetAlert(e1.Message), true, null);
                }
                catch
                {
                    ActivityIndicator.StopAnimating();
                    LogInButton.Enabled = true;
                    RegistrationButton.Enabled = true;
                    PresentViewController(GetAlertsClass.GetAlert("Не удалось подключиться к серверу"), true, null);
                }
            };


        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            _didShowNotificationObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.DidShowNotification, KeyBoardDidShow);

            _willHideNotificationObserver = NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, KeyBoardWillHide);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            if (_didShowNotificationObserver != null)
            {
                NSNotificationCenter.DefaultCenter.RemoveObserver(_didShowNotificationObserver);
            }

            if (_willHideNotificationObserver != null)
            {
                NSNotificationCenter.DefaultCenter.RemoveObserver(_willHideNotificationObserver);
            }
        }

        private void KeyBoardDidShow(NSNotification notification)
        {
            // get the keyboard size
            CoreGraphics.CGRect notificationBounds = UIKeyboard.BoundsFromNotification(notification);

            // Find what opened the keyboard
            foreach (UIView view in this.View.Subviews)
            {
                if (view.IsFirstResponder)
                    activeTextFieldView = view;
            }

            // Bottom of the controller = initial position + height + offset
            bottomOfTheActiveTextField = (activeTextFieldView.Frame.Y + activeTextFieldView.Frame.Height + offsetBetweenKeybordAndTextField);

            // Calculate how far we need to scroll
            amountToScroll = (notificationBounds.Height - (View.Frame.Size.Height - bottomOfTheActiveTextField));

            // Perform the scrolling
            if (amountToScroll > 0)
            {
                bottomOfTheActiveTextField -= alreadyScrolledAmount;
                amountToScroll = (notificationBounds.Height - (View.Frame.Size.Height - bottomOfTheActiveTextField));
                alreadyScrolledAmount += amountToScroll;
                isMoveRequired = true;
                ScrollTheView(isMoveRequired);
            }
            else
            {
                isMoveRequired = false;
            }

        }

        private void KeyBoardWillHide(NSNotification notification)
        {
            bool wasViewMoved = !isMoveRequired;
            if (isMoveRequired) { ScrollTheView(wasViewMoved); }
        }

        private void ScrollTheView(bool move)
        {

            // scroll the view up or down
            UIView.BeginAnimations(string.Empty, System.IntPtr.Zero);
            UIView.SetAnimationDuration(0.3);

            CoreGraphics.CGRect frame = View.Frame;

            if (move)
            {
                frame.Y -= amountToScroll;
            }
            else
            {
                frame.Y += alreadyScrolledAmount;
                amountToScroll = 0;
                alreadyScrolledAmount = 0;
            }

            View.Frame = frame;
            UIView.CommitAnimations();
        }

    }
}
