using AutoMapper;
using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.Shops;
using BarkodWeb.Service.Extensions;
using BarkodWeb.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BarkodWeb.Views.Shared.ViewComponents
{
    public class UserToShopViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IShopService shopService;
        private readonly IMapper mapper;

        public UserToShopViewComponent(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, IShopService shopService, IMapper mapper)
        {
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
            this.shopService = shopService;
            this.mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var shops = await shopService.GetAllShopAsyncWitoutModel();


            var user = httpContextAccessor.HttpContext.User.GetLoggedInUserId();
            var UserToShop = await userManager.FindByIdAsync(user.ToString());

            if (UserToShop != null)
            {
                ViewBag.UserShop = UserToShop.ShopId;
            }

            


            return View(shops);



        }










    }
}
