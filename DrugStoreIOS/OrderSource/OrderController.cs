using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace DrugStoreIOS
{
    public class OrderController
    {
        private static OrderController ThisItem;
        private MobileServiceClient MobileService;
        private IMobileServiceTable<Orders> UserOrders;
        public List<OrderItem> ListOfOrders { get; set; }

        private OrderController()
        {
            MobileService = new MobileServiceClient("https://some.azurewebsites.net");
        }

        public static async Task<OrderController> GetInstance()
        {
            if (ThisItem == null)
            {
                ThisItem = new OrderController();
                await ThisItem.Init();
                ThisItem.UserOrders = ThisItem.MobileService.GetTable<Orders>();
            }
            return ThisItem;
        }

        public async Task AddOrder(Orders item)
        {
            await UserOrders.InsertAsync(item);
        }

        public async Task UpdateOrder(Orders item)
        {
            var itemToedit = await UserOrders.Where(ItemToFind => ItemToFind.DrugName == item.DrugName && ItemToFind.CustomerName==AppDelegate.UserName).ToListAsync();
            itemToedit[0].Derived = item.Derived;
            itemToedit[0].Count = item.Count;
            await UserOrders.UpdateAsync(itemToedit[0]);
        }

        private async Task Init()
        {
            var paramDictionary = new Dictionary<string, string>();
            paramDictionary.Add("UsName", AppDelegate.UserName);
            ListOfOrders = await MobileService.InvokeApiAsync <List<OrderItem>>("JoinForUser",System.Net.Http.HttpMethod.Get, paramDictionary );
        }
    }
}
