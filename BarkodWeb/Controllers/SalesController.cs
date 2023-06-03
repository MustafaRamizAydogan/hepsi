using AutoMapper;
using BarkodWeb.Controllers.Product;
using BarkodWeb.Data.UnitOfWorks;
using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.Sales;
using BarkodWeb.Service.Extensions;
using BarkodWeb.Service.Services.Abstractions;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BarkodWeb.Controllers.Sales
{
    public class SalesController : Controller
    {
        private readonly ILogger<ProductController> logger;
        private readonly IStockService stockService;
        private readonly ILowerGroupService lowerGroupService;
        private readonly IMainGroupService mainGroupService;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;
      
        private readonly ISaleService saleService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SalesController(ILogger<ProductController> logger, IStockService stockService, ILowerGroupService lowerGroupService, IMainGroupService mainGroupService, IMapper mapper, IToastNotification toast,ISaleService saleService)
        {
            this.logger = logger;
            this.stockService = stockService;
            this.lowerGroupService = lowerGroupService;
            this.mainGroupService = mainGroupService;
            this.mapper = mapper;
            this.toast = toast;
      
            this.saleService = saleService;
            this.httpContextAccessor = httpContextAccessor;
        }




        //---------------------------------------SATIŞ YAPMA Safyası---------------------------------------------------


        [HttpGet]
        public async Task<IActionResult> Index()
        {

            //---------SATIŞLARI LİSTELEME--------

            var sales = await saleService.GetAllSalesAsync();
            var main = await mainGroupService.GetAllMainGroups();
            ViewBag.Sales = sales;
            ViewBag.main = main.ToList();


            return View();

        }




        //---------------------------------------NAKİT SATIŞ  EKLEME---------------------------------------------------

        [HttpPost]
        public async Task<IActionResult> Nakit(SaleAddViewModel saleAddViewModel)
        {

            //---------NAKİT EKLE--------

            var kontrol = await saleService.CreatSaleNakitAsync(saleAddViewModel);



            //---------EKLEME YAPARKEN KONTROL ETME--------


            if (kontrol == 1)
            {
                toast.AddSuccessToastMessage("Nakit Satış Başarılı", new ToastrOptions() { Title = "İşlem" });
                return RedirectToAction("Index", "Sales");
            }
            else if (kontrol == 2)
            {
                toast.AddErrorToastMessage("Stokda Ürün Bulunmuyor", new ToastrOptions() { Title = "İşlem" });
                return RedirectToAction("Index", "Sales");
            }
            else
            {
                toast.AddErrorToastMessage("Stokda Ürün Kalmadı", new ToastrOptions() { Title = "İşlem" });
                return RedirectToAction("Index", "Sales");
            }

        }




        //---------------------------------------KART SATIŞ  EKLEME---------------------------------------------------


        [HttpPost]
        public async Task<IActionResult> Kart(SaleAddViewModel saleAddViewModel)
        {

            //---------KART EKLE--------

            var kontrol = await saleService.CreatSaleKartAsync(saleAddViewModel);


            //---------EKLEME YAPARKEN KONTROL ETME--------


            if (kontrol == 1)
            {
                toast.AddInfoToastMessage("Kart Satış Başarılı", new ToastrOptions() { Title = "İşlem" });
                return RedirectToAction("Index", "Sales");
            }
            else if (kontrol == 2)
            {
                toast.AddErrorToastMessage("Stokda Ürün Bulunmuyor", new ToastrOptions() { Title = "İşlem" });
                return RedirectToAction("Index", "Sales");
            }
            else
            {
                toast.AddErrorToastMessage("Stokda Ürün Kalmadı", new ToastrOptions() { Title = "İşlem" });
                return RedirectToAction("Index", "Sales");
            }

        }




        //---------------------------------------SATIŞ SİLME İŞLEMİ---------------------------------------------------

        public async Task<IActionResult> Delete(Guid SaleId)
        {

            //---------SİLME--------

            await saleService.DeleteSaleAsync(SaleId);


            return RedirectToAction("Index", "Sales");
        }















    }
}
