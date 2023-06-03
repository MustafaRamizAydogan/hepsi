using AutoMapper;
using BarkodWeb.Data.UnitOfWorks;
using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.Stocks;
using BarkodWeb.Service.Extensions;
using BarkodWeb.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace BarkodWeb.Service.Services.Concretes
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
       
        private readonly UserManager<AppUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public StockService(IUnitOfWork unitOfWork, IMapper mapper,UserManager<AppUser> userManager,IHttpContextAccessor httpContextAccessor)

        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task CreatStockAsync(StockAddViewModel stockAddViewModel)
        {
            var user = httpContextAccessor.HttpContext.User.GetLoggedInUserId();
            var UserToShop = await userManager.FindByIdAsync(user.ToString());

            var lowerıd= await unitOfWork.GetRepository<LowerGroup>().GetByGuidAsync(stockAddViewModel.LowerGroupId);

            var stockAdd = new Stock
            {

                AlisFiyat = stockAddViewModel.AlisFiyat,
                Barkod = stockAddViewModel.Barkod,
                Gram = stockAddViewModel.Gram,
                LowerGroupId = stockAddViewModel.LowerGroupId,
                MainGroupId = lowerıd.MainGroupId,
                ParaKuru = stockAddViewModel.ParaKuru,
                Stok = stockAddViewModel.Stok,
                UrunBirimi = stockAddViewModel.UrunBirimi,
                SatisFiyat = stockAddViewModel.SatisFiyat,
                ShopId = UserToShop.ShopId.Value

            };

            await unitOfWork.GetRepository<Stock>().AddAsync(stockAdd);
            await unitOfWork.SaveAsync();

        }

        public async Task<List<Stock>> GetAllStocksWithLowerIdAsync(Guid LowerId)
        {

            var stocks = await unitOfWork.GetRepository<Stock>().GetAllAsync(z => z.LowerGroupId == LowerId);



            return stocks;
        }

        public async Task<Stock> GetAllStocksWithBarkodAsync(string barkod)
        {
            var user = httpContextAccessor.HttpContext.User.GetLoggedInUserId();
            var UserToShop = await userManager.FindByIdAsync(user.ToString());

            var stocks = await unitOfWork.GetRepository<Stock>().GetAsync(x => x.Barkod == barkod);



            return stocks;
        }

        public async Task<List<StockViewModel>> GetAllStocksWithMainAndLowerGroupAsync()
        {
            var user = httpContextAccessor.HttpContext.User.GetLoggedInUserId();
            var UserToShop = await userManager.FindByIdAsync(user.ToString());

            var stocks = await unitOfWork.GetRepository<Stock>().GetAllAsync(z=>z.ShopId==UserToShop.ShopId, x => x.MainGroup , y => y.LowerGroup);

            var map = mapper.Map<List<StockViewModel>>(stocks);

            return map;
        }


        public async Task<List<Stock>> GetAllStocksAsync(Guid ShopId)
        {
           
            var stocks = await unitOfWork.GetRepository<Stock>().GetAllAsync(z => z.ShopId == ShopId);

            

            return stocks;
        }

        public async Task<StockViewModel> GetStocksWithMainAndLowerGroupAndIdAsync(Guid StockId)
        {
           
            var stock = await unitOfWork.GetRepository<Stock>().GetAsync(x => x.Id == StockId,x=>x.LowerGroup);

            var map = mapper.Map<StockViewModel>(stock);

            return map;
        }

        public async Task UpdateStockAsync (StockUpdateViewModel stockUpdateViewModel)
        {
            var stock = await unitOfWork.GetRepository<Stock>().GetAsync(x => x.Id == stockUpdateViewModel.Id, x => x.LowerGroup);

            stock.Stok=stockUpdateViewModel.Stok;
            stock.Tarih=DateTime.Now;
            stock.SatisFiyat=stockUpdateViewModel.SatisFiyat;
            stock.AlisFiyat = stockUpdateViewModel.AlisFiyat;
            stock.UrunBirimi=stockUpdateViewModel.UrunBirimi;
            stock.Barkod=stockUpdateViewModel.Barkod;
            stock.Gram=stockUpdateViewModel.Gram;
            stock.LowerGroupId=stockUpdateViewModel.LowerGroupId;
            stock.MainGroupId=stockUpdateViewModel.MainGroupId;
            stock.ParaKuru=stockUpdateViewModel.ParaKuru;
            

            await unitOfWork.GetRepository<Stock>().UpdateAsync(stock);
            await unitOfWork.SaveAsync();


        }
        public async Task DeleteStockAsync (Guid StockId)
        {
            var stock = await unitOfWork.GetRepository<Stock>().GetAsync(x => x.Id == StockId, x => x.LowerGroup);
            await unitOfWork.GetRepository<Stock>().DeleteAsync(stock);
            await unitOfWork.SaveAsync();

        }


        public async Task<bool> HasName(string Name)
        {

            var stockname = await unitOfWork.GetRepository<Stock>().AnyAsync(x => x.Barkod == Name);

            return stockname;
        }

    }
}
