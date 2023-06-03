using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Service.Services.Abstractions
{
    public interface IStockService
    {
        Task<List<StockViewModel>> GetAllStocksWithMainAndLowerGroupAsync();


        Task CreatStockAsync(StockAddViewModel stockAddViewModel);

        Task<StockViewModel> GetStocksWithMainAndLowerGroupAndIdAsync(Guid StockId);
        Task<Stock> GetAllStocksWithBarkodAsync(string barkod);
        Task<List<Stock>> GetAllStocksWithLowerIdAsync(Guid LowerId);
        Task<List<Stock>> GetAllStocksAsync(Guid ShopId);
        Task UpdateStockAsync(StockUpdateViewModel stockUpdateViewModel);
        Task DeleteStockAsync(Guid StockId);

        Task<bool> HasName(string Name);
    }
}
