using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.MainGroups;
using BarkodWeb.Entity.ViewModels.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Service.Services.Abstractions
{
    public interface IMainGroupService
    {
        Task<List<MainGroupViewModel>> GetAllMainGroups();

        Task CreatMainGroupAsync(StockAddViewModel stockAddViewModel);


        Task Delete(MainGroup mainGroup);

        Task<List<MainGroup>> GetAllMainGroupsWithShopId(Guid ShopId);

    }
}
