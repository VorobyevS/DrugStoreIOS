using System;

using UIKit;
namespace DrugStoreIOS
{
    public static class GetAlertsClass
    {
        public static UIAlertController GetAlert(string message)
        {
            UIAlertController alert = UIAlertController.Create("Ошибка", message, UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("ОК", UIAlertActionStyle.Default, null));
            return alert;
        }

        public static UIAlertController GetAlertForOrder(string message)
        {
            UIAlertController alert = UIAlertController.Create("Заказ", message, UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("ОК", UIAlertActionStyle.Default, null));
            return alert;
        }
    }
}
