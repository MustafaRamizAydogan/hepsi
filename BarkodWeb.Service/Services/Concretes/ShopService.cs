using AutoMapper;
using BarkodWeb.Data.UnitOfWorks;
using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.Sales;
using BarkodWeb.Entity.ViewModels.Shops;
using BarkodWeb.Service.Extensions;
using BarkodWeb.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BarkodWeb.Service.Services.Concretes
{
    public class ShopService : IShopService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<AppUser> userManager;

        public ShopService(IUnitOfWork unitOfWork, IMapper mapper,IHttpContextAccessor httpContextAccessor,UserManager<AppUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public async Task<List<ShopViewModel>> GetAllShopAsync()
        {
            //---------USER YAKALAMA--------
            var userYakala = httpContextAccessor.HttpContext.User.GetLoggedInUserId();
            var User = await userManager.FindByIdAsync(userYakala.ToString());

            var Shops = await unitOfWork.GetRepository<Shop>().GetAllAsync(x=>x.BossId==User.Id);

            var map = mapper.Map<List<ShopViewModel>>(Shops);

            return map;
        }

        public async Task<string> GetShopWithIdAsync(Guid ShopId)
        {
            var Shop = await unitOfWork.GetRepository<Shop>().GetByGuidAsync(ShopId);
            if (Shop == null)
            {
                return " ";
            }
            else
            {
                return Shop.Adı;
            }



        }

        public async Task<string> GetShopWithNameAsync(string name)
        {
             var Shop = await unitOfWork.GetRepository<Shop>().GetAsync(x=>x.Adı==name);
         
          
                return Shop.Id.ToString();
           



        }


        public async Task<List<Shop>> GetAllShopAsyncWitoutModel()
        {


            //---------USER YAKALAMA--------
            var userYakala = httpContextAccessor.HttpContext.User.GetLoggedInUserId();
            var User = await userManager.FindByIdAsync(userYakala.ToString());


            var Shops = await unitOfWork.GetRepository<Shop>().GetAllAsync(x=>x.BossId==User.Id);

            return Shops;
        }

        public async Task CreatShopAsync(ShopViewModel shopViewModel)
        {
            //---------USER YAKALAMA--------
            var userYakala = httpContextAccessor.HttpContext.User.GetLoggedInUserId();
            var User = await userManager.FindByIdAsync(userYakala.ToString());


            var ShopAdd = new Shop
            {

                Adı = shopViewModel.Adı.ToUpper(),
                BossId= User.Id
               

            };





            await unitOfWork.GetRepository<Shop>().AddAsync(ShopAdd);
            await unitOfWork.SaveAsync();

        }


        public async Task CreatShopAsync(string name)
        {



            var ShopAdd = new Shop
            {

                Adı = name

            };





            await unitOfWork.GetRepository<Shop>().AddAsync(ShopAdd);
            await unitOfWork.SaveAsync();

        }

        public async Task Update(string ShopName,Guid userId)
        {

            var shop = await unitOfWork.GetRepository<Shop>().GetAsync(x => x.Adı == ShopName);

           
            shop.BossId = userId;

               
           



            await unitOfWork.GetRepository<Shop>().UpdateAsync(shop);

            await unitOfWork.SaveAsync();

        }



        public async Task DeleteSaleAsync(Guid ShopId)
        {
            var Shops = await unitOfWork.GetRepository<Shop>().GetAsync(x => x.Id == ShopId);



            await unitOfWork.GetRepository<Shop>().DeleteAsync(Shops);
            await unitOfWork.SaveAsync();

        }
    }
}
