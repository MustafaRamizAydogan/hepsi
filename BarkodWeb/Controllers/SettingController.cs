using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.Sales;
using BarkodWeb.Entity.ViewModels.Shops;
using BarkodWeb.Service.Services.Abstractions;
using BarkodWeb.Service.Services.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace BarkodWeb.Controllers
{
    public class SettingController : Controller
    {
        private readonly IShopService shopService;
        private readonly IToastNotification toast;
        private readonly UserManager<AppUser> userManager;
        private readonly IStockService stockService;
        private readonly ISaleService saleService;
        private readonly ILowerGroupService lowerGroupService;
        private readonly IMainGroupService mainGroupService;

        public SettingController(IShopService shopService, IToastNotification toast,UserManager<AppUser> userManager,IStockService stockService,ISaleService saleService,ILowerGroupService lowerGroupService,IMainGroupService mainGroupService)
        {
            this.shopService = shopService;
            this.toast = toast;
            this.userManager = userManager;
            this.stockService = stockService;
            this.saleService = saleService;
            this.lowerGroupService = lowerGroupService;
            this.mainGroupService = mainGroupService;
        }


        //---------------------------------------MAĞAZA EKLEME İŞLEMİ---------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> ShopAdd()
        {
            //---------MAGAZALARI GETİMEK LİSTELEMEK--------
            var Shops = await shopService.GetAllShopAsync();
            ViewBag.Shops = Shops;


            return View();
        }


        //---------------------------------------MAĞAZA EKLEME İŞLEMİ POST---------------------------------------------------

        [HttpPost]
        public async Task<IActionResult> ShopAdd(ShopViewModel shopViewModel)
        {
            //---------MAĞAZA EKLE--------
            await shopService.CreatShopAsync(shopViewModel);


            toast.AddSuccessToastMessage("Mağaza Ekleme Başarılı", new ToastrOptions() { Title = "İşlem" });

            return RedirectToAction("ShopAdd", "Setting");
        }




        //---------------------------------------MAĞAZA SİLME İŞLEMİ---------------------------------------------------

        public async Task<IActionResult> Delete(Guid ShopId)
        {

            var users = await userManager.Users.Where(x => x.ShopId == ShopId).ToListAsync();
            if (users != null)
            {
                foreach (var item in users)
                {
                    await userManager.DeleteAsync(item);
                }
            }

            var stock = await stockService.GetAllStocksAsync(ShopId);
            if (stock != null)
            {
                foreach (var item in stock)
                {
                    await stockService.DeleteStockAsync(item.Id);
                }
               
            }
            var sales= await saleService.GetAllSalesWithShopIdAsync(ShopId);
            if (sales != null)
            {
                foreach (var item in sales)
                {
                    await saleService.DeleteAsync(item.Id);
                }

            }
            var lowerGroup = await lowerGroupService.GetAllLowerGroupWithShopId(ShopId);
            
            if (lowerGroup != null)
            {
                foreach (var item in lowerGroup)
                {
                    await lowerGroupService.Delete(item);
                }
            }

            var mainGroup = await mainGroupService.GetAllMainGroupsWithShopId(ShopId);
            if (mainGroup != null)
            {
                foreach (var item in mainGroup)
                {
                    await mainGroupService.Delete(item);
                }
            }





            //---------MAĞAZA SİLME--------
            await shopService.DeleteSaleAsync(ShopId);

            toast.AddSuccessToastMessage("Mağaza Silme Başarılı", new ToastrOptions() { Title = "İşlem" });


            return RedirectToAction("ShopAdd", "Setting");
        }

    }
}
