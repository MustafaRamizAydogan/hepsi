using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.Sales;
using BarkodWeb.Entity.ViewModels.Shops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Service.Services.Abstractions
{
    public interface IShopService
    {

        Task<List<ShopViewModel>> GetAllShopAsync();
        Task CreatShopAsync(ShopViewModel shopViewModel);

        Task CreatShopAsync(string name);
        Task Update(string ShopName,Guid userId);

        Task<string> GetShopWithNameAsync(string name);
        Task DeleteSaleAsync(Guid ShopId);
        Task<List<Shop>> GetAllShopAsyncWitoutModel();
        Task<string> GetShopWithIdAsync(Guid ShopId);

    }
}
