using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.WindowsAzure.MobileServices;


namespace DrugStoreIOS
{
    public class GoodsController
    {
        private static GoodsController ThisItem;
        private MobileServiceClient MobileService;
        private IMobileServiceTable<Goods> GoodsTable;
        public List<Goods> List { get; set; }
        private int countOfItems = 0;
        private int countOfAllItems = 0;

        private GoodsController()
        {
            MobileService = new MobileServiceClient("https://some.azurewebsites.net");
            GoodsTable = MobileService.GetTable<Goods>();
            List = new List<Goods>();
        }

        public static GoodsController GetInstance()
        {
            if (ThisItem == null)
                ThisItem = new GoodsController();
            return ThisItem;
        }

        public async Task<bool> GetNext()
        {
            if(countOfItems==0)
            {
                await CountOfAllItems();
            }
            if (countOfItems >= countOfAllItems)
            {
                return false;
            }
            else
            {
                this.List.AddRange(await GoodsTable.Skip(countOfItems).Take(10).ToListAsync());
                countOfItems += 10;
                return true;
            }
        }

        public async Task<List<Goods>> Search(string name)
        {
            
            return await GoodsTable.Where(item => item.Name.Contains(name)).ToListAsync();
        }

        public async Task CountOfAllItems()
        {
            var takeTotal = await GoodsTable.IncludeTotalCount().ToEnumerableAsync();
            var totalcount = takeTotal as IQueryResultEnumerable<Goods>;
            countOfAllItems = (int)totalcount.TotalCount;
        }
    }
}
