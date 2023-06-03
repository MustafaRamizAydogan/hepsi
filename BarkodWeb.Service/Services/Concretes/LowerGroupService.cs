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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Service.Services.Concretes
{
    public class LowerGroupService : ILowerGroupService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<AppUser> userManager;

        public LowerGroupService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public async Task CreatLowerGroupAsync(StockAddViewModel stockAddViewModel)
        {
            var user = httpContextAccessor.HttpContext.User.GetLoggedInUserId();
            var UserToShop = await userManager.FindByIdAsync(user.ToString());
            var lower = new LowerGroup
            {
                AltGrup = stockAddViewModel.AltGrup,
                MainGroupId = stockAddViewModel.MainGroupId,
                ShopId=UserToShop.ShopId

            };

            await unitOfWork.GetRepository<LowerGroup>().AddAsync(lower);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<LowerGroupViewModel>> GetAllLowerGroup()
        {
            var lowergroup = await unitOfWork.GetRepository<LowerGroup>().GetAllAsync();
            var map = mapper.Map<List<LowerGroupViewModel>>(lowergroup);
            return map;
        }


        public async Task<List<LowerGroupViewModel>> GetAllLowerGroup(Guid id)
        {
            var lowergroup = await unitOfWork.GetRepository<LowerGroup>().GetAllAsync(x=>x.MainGroupId==id);
            var map = mapper.Map<List<LowerGroupViewModel>>(lowergroup);
            return map;
        }


        public async Task<List<LowerGroup>> GetAllLowerGroupWithShopId(Guid shopId)
        {
            var lowergroup = await unitOfWork.GetRepository<LowerGroup>().GetAllAsync(x=>x.ShopId==shopId);
            
            return lowergroup;
        }

        public async Task  Delete(LowerGroup lowerGroup)
        {
          
            await unitOfWork.GetRepository<LowerGroup>().DeleteAsync(lowerGroup);

            await unitOfWork.SaveAsync();


        }
     

    }
}
