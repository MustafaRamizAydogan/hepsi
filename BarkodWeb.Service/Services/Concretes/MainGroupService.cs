using AutoMapper;
using BarkodWeb.Data.UnitOfWorks;
using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.LowerGroups;
using BarkodWeb.Entity.ViewModels.MainGroups;
using BarkodWeb.Entity.ViewModels.Stocks;
using BarkodWeb.Service.Extensions;
using BarkodWeb.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Service.Services.Concretes
{
    public class MainGroupService : IMainGroupService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<AppUser> userManager;

        public MainGroupService(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public async Task CreatMainGroupAsync(StockAddViewModel stockAddViewModel)
        {
            var user = httpContextAccessor.HttpContext.User.GetLoggedInUserId();
            var UserToShop = await userManager.FindByIdAsync(user.ToString());

            var Main = new MainGroup
            {
               AnaGrup =stockAddViewModel.AnaGrup,
              ShopId=UserToShop.ShopId

            };

            await unitOfWork.GetRepository<MainGroup>().AddAsync(Main);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<MainGroupViewModel>> GetAllMainGroups()
        {
            var MainGroup= await unitOfWork.GetRepository<MainGroup>().GetAllAsync();
            var map = mapper.Map<List<MainGroupViewModel>>(MainGroup);
            return map;
        }


        public async Task<List<MainGroup>> GetAllMainGroupsWithShopId(Guid ShopId)
        {
            var MainGroup = await unitOfWork.GetRepository<MainGroup>().GetAllAsync(x=>x.ShopId== ShopId);
            
            return MainGroup;
        }


        public async Task Delete(MainGroup mainGroup)
        {
            
            await unitOfWork.GetRepository<MainGroup>().DeleteAsync(mainGroup);

            await unitOfWork.SaveAsync();


        }

    }
}
