using System;
using System.Text.RegularExpressions;
namespace DrugStoreIOS
{
    public static class LoginAndPasswordCheck
    {
        public static void LoginCheck(string input)
        {
            if (!Regex.IsMatch(input, @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$"))
                throw new FiledsCheckException("Неверный логин");
        }

        public static void PasswordCheck(string input)
        {
            if (!Regex.IsMatch(input, @"^\w{6,}$"))
                throw new FiledsCheckException("Неверный пароль(миниммум 6 символов)");
        }

        public static void AdressCheck(string input)
        {
            if (!Regex.IsMatch(input, @"^\w+"))
                throw new FiledsCheckException("Адресс некорректен");
        }

        public static void PhoneCheck(string input)
        {
            if (!Regex.IsMatch(input, @"^\d{12}$"))
                throw new FiledsCheckException("Номер некорректен");
        }
    }

    public class FiledsCheckException : Exception
    {
        public FiledsCheckException(string message): base(message){}
    }
}
