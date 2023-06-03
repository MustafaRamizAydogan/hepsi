using AutoMapper;
using BarkodWeb.Data.UnitOfWorks;
using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.Sales;
using BarkodWeb.Entity.ViewModels.Stocks;
using BarkodWeb.Service.Extensions;
using BarkodWeb.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Service.Services.Concretes
{
    public class SaleService : ISaleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<AppUser> userManager;

        public SaleService(IUnitOfWork unitOfWork, IMapper mapper,IHttpContextAccessor httpContextAccessor,UserManager<AppUser> userManager)

        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public async Task<int> CreatSaleNakitAsync(SaleAddViewModel saleAddViewModel)
        {
            var user = httpContextAccessor.HttpContext.User.GetLoggedInUserId();
            var UserToShop = await userManager.FindByIdAsync(user.ToString());


            var stocks = await unitOfWork.GetRepository<Stock>().GetAsync(x => x.Barkod == saleAddViewModel.Barkod, y => y.LowerGroup);

            if (stocks.ShopId == UserToShop.ShopId)
            {

                if (stocks.Stok-saleAddViewModel.SatılanStok>=0)
            {
                var SaleAdd = new Sale
                {

                    AlisFiyat = stocks.AlisFiyat,
                    Barkod = stocks.Barkod,
                    Gram = saleAddViewModel.Gram,
                    LowerGroupId = stocks.LowerGroupId,
                    MainGroupId = stocks.LowerGroup.MainGroupId,
                    ParaKuru = stocks.ParaKuru,
                    SatılanStok = saleAddViewModel.SatılanStok,
                    UrunBirimi = stocks.UrunBirimi,
                    SatisFiyat = stocks.SatisFiyat,
                    Hasılat = saleAddViewModel.Hasılat,
                    SatisTarih = DateTime.Now,
                    OdemeTuru = "Nakit",
                    ShopId = UserToShop.ShopId


                };
                stocks.Stok -= saleAddViewModel.SatılanStok;

                stocks.Gram -= saleAddViewModel.Gram;


                await unitOfWork.GetRepository<Stock>().UpdateAsync(stocks);

                await unitOfWork.GetRepository<Sale>().AddAsync(SaleAdd);
               await unitOfWork.SaveAsync();
                return 1;
            }
            else
            {
                return 0;
            }


            }
            else
            {
                return 2;
            }



        }
        public async Task<int> CreatSaleKartAsync(SaleAddViewModel saleAddViewModel)
        {
            var user = httpContextAccessor.HttpContext.User.GetLoggedInUserId();
            var UserToShop = await userManager.FindByIdAsync(user.ToString());
            var stocks = await unitOfWork.GetRepository<Stock>().GetAsync(x => x.Barkod == saleAddViewModel.Barkod , y => y.LowerGroup);

            if (stocks.ShopId==UserToShop.ShopId)
            {
                if (stocks.Stok - saleAddViewModel.SatılanStok >= 0)
                {
                    var SaleAdd = new Sale
                    {

                        AlisFiyat = stocks.AlisFiyat,
                        Barkod = stocks.Barkod,
                        Gram = saleAddViewModel.Gram,
                        LowerGroupId = stocks.LowerGroupId,
                        MainGroupId = stocks.LowerGroup.MainGroupId,
                        ParaKuru = stocks.ParaKuru,
                        SatılanStok = saleAddViewModel.SatılanStok,
                        UrunBirimi = stocks.UrunBirimi,
                        SatisFiyat = stocks.SatisFiyat,
                        Hasılat = saleAddViewModel.Hasılat,
                        SatisTarih = DateTime.Now,
                        OdemeTuru = "Kart",
                        ShopId = UserToShop.ShopId

                    };
                    stocks.Stok -= saleAddViewModel.SatılanStok;

                    stocks.Gram -= saleAddViewModel.Gram;


                    await unitOfWork.GetRepository<Stock>().UpdateAsync(stocks);

                    await unitOfWork.GetRepository<Sale>().AddAsync(SaleAdd);
                    await unitOfWork.SaveAsync();
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            else
            {
                return 2;
            }
           

        }

        public async Task<List<SaleAddViewModel>> GetAllSalesAsync()

        {

            var user = httpContextAccessor.HttpContext.User.GetLoggedInUserId();
         
            var UserToShop = await userManager.FindByIdAsync(user.ToString());

            var Sales = await unitOfWork.GetRepository<Sale>().GetAllAsync(x=> x.ShopId== UserToShop.ShopId, x => x.MainGroup, y => y.LowerGroup);

            var map = mapper.Map<List<SaleAddViewModel>>(Sales);

            return map;
        }

        public async Task<List<Sale>> GetAllSalesWithShopIdAsync(Guid ShopId)

        {


            var Sales = await unitOfWork.GetRepository<Sale>().GetAllAsync(x => x.ShopId == ShopId);

           

            return Sales;
        }



        public async Task DeleteSaleAsync(Guid SaleId)
        {
            var sales = await unitOfWork.GetRepository<Sale>().GetAsync(x => x.Id == SaleId);


            var stocks = await unitOfWork.GetRepository<Stock>().GetAsync(x => x.Barkod == sales.Barkod, y => y.LowerGroup);

            stocks.Stok += sales.SatılanStok;

            stocks.Gram += sales.Gram;


            await unitOfWork.GetRepository<Stock>().UpdateAsync(stocks);
            var sale = await unitOfWork.GetRepository<Sale>().GetAsync(x => x.Id == SaleId, x => x.LowerGroup);
            await unitOfWork.GetRepository<Sale>().DeleteAsync(sale);
            await unitOfWork.SaveAsync();

        }


        public async Task DeleteAsync(Guid SaleId)
        {
            var Sale = await unitOfWork.GetRepository<Sale>().GetAsync(x => x.Id == SaleId, x => x.LowerGroup);
            await unitOfWork.GetRepository<Sale>().DeleteAsync(Sale);
            await unitOfWork.SaveAsync();

        }
    }
}
