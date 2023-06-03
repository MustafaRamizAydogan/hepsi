using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Service.Services.Abstractions
{
    public interface ISaleService
    {
        Task<int> CreatSaleNakitAsync(SaleAddViewModel saleAddViewModel);
        Task<int> CreatSaleKartAsync(SaleAddViewModel saleAddViewModel);
        Task<List<SaleAddViewModel>> GetAllSalesAsync();

        Task<List<Sale>> GetAllSalesWithShopIdAsync(Guid ShopId);
        Task DeleteSaleAsync(Guid SaleId);

        Task DeleteAsync(Guid SaleId);

    }
}
