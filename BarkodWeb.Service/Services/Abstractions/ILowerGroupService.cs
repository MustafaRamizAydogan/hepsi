using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.LowerGroups;
using BarkodWeb.Entity.ViewModels.MainGroups;
using BarkodWeb.Entity.ViewModels.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Service.Services.Abstractions
{
    public interface ILowerGroupService
    {
        Task<List<LowerGroupViewModel>> GetAllLowerGroup();

        Task CreatLowerGroupAsync(StockAddViewModel stockAddViewModel);

        Task<List<LowerGroupViewModel>> GetAllLowerGroup(Guid id);

        Task<List<LowerGroup>> GetAllLowerGroupWithShopId(Guid shopId);

        Task Delete(LowerGroup lowerGroup);




    }
}
