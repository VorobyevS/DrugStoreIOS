using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace DrugStoreIOS
{
    public static class UsersCheckClass
    {
        private static MobileServiceClient MobileService = new MobileServiceClient("https://some.azurewebsites.net");

        public static async Task TryToRegister(Customers item)
        {
            IMobileServiceTable<Customers> CustomersTable = MobileService.GetTable<Customers>();

            List<Customers> Customers = await CustomersTable.Where(customer => customer.Name == item.Name).ToListAsync();

            if (Customers.Count == 0)
            {
                item.Password = item.Password.GetHashCode().ToString();
                await CustomersTable.InsertAsync(item);
                AppDelegate.UserName = item.Name;
            }
            else
                throw new UserCheckClassException("Пользователь уже существует");
        }

        public static async Task TryToLogIn(Customers item)
        {
            IMobileServiceTable<Customers> CustomersTable = MobileService.GetTable<Customers>();

            List<Customers> Customers = await CustomersTable.Where(customer => customer.Name == item.Name && customer.Password ==item.Password.GetHashCode().ToString()).ToListAsync();

            if (Customers.Count != 1)
                throw new UserCheckClassException("Логин или пароль введен не верно");
            else
                AppDelegate.UserName = item.Name;
        }
    }

    public class UserCheckClassException : ApplicationException
    {
        public UserCheckClassException(string message) : base(message){}
    }
}
