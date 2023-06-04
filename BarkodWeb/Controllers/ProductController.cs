using AutoMapper;
using BarkodWeb.Data.UnitOfWorks;
using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.Stocks;
using BarkodWeb.Service.Extensions;
using BarkodWeb.Service.FluentValidations;
using BarkodWeb.Service.Services.Abstractions;
using BarkodWeb.Service.Services.Concretes;
using FluentValidation;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using NToastNotify;

namespace BarkodWeb.Controllers.Product
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IStockService stockService;
        private readonly ILowerGroupService lowerGroupService;
        private readonly IMainGroupService mainGroupService;
        private readonly IMapper mapper;

        private readonly IToastNotification toast;
        private readonly IValidator<StockAddViewModel> validator;

        public ProductController(ILogger<ProductController> logger, IStockService stockService, ILowerGroupService lowerGroupService, IMainGroupService mainGroupService, IMapper mapper, IToastNotification toast, IValidator<StockAddViewModel> validator)
        {
            _logger = logger;
            this.stockService = stockService;
            this.lowerGroupService = lowerGroupService;
            this.mainGroupService = mainGroupService;
            this.mapper = mapper;

            this.toast = toast;
            this.validator = validator;
        }




        //---------------------------------------STOCK  EKLEME---------------------------------------------------


        [HttpGet]
        public async Task<IActionResult> Index()
        {

         

            return View(new StockAddViewModel { lowerGroups = lower, MainGroups = main });
        }


        //---------------------------------------STOCK  EKLEME POST---------------------------------------------------

        [HttpPost]

        public async Task<IActionResult> Index(StockAddViewModel stockAddViewModel)
        {

            //--- Fluent Validations Kullanımı-----

            var map = mapper.Map<Stock>(stockAddViewModel);
            var context = new ValidationContext<object>(stockAddViewModel);
            var resualt = await validator.ValidateAsync(context);




            //---------LOWER VE MAİN GROUP LİSTELEME--------

            var lower = await lowerGroupService.GetAllLowerGroup();
            var main = await mainGroupService.GetAllMainGroups();


            //---------VALİDATİON KONTROL--------

            if (resualt.IsValid)
            {
                //---------STOK GETİRME--------

                var ab = await stockService.GetAllStocksWithMainAndLowerGroupAsync();


                if (ab.Count == 0)
                {
                    await stockService.CreatStockAsync(stockAddViewModel);
                    toast.AddSuccessToastMessage("Ürünü Ekleme Başarılı", new ToastrOptions() { Title = "İşlem" });

                    return RedirectToAction("Listele", "Product");

                }

                foreach (var control in ab)
                {

                    //---------STOK KONTROL--------

                    if (control.Barkod == stockAddViewModel.Barkod)
                    {
                        toast.AddWarningToastMessage("Barkod Zaten Bulunuyor", new ToastrOptions() { Title = "İşlem" });


                        return View(new StockAddViewModel { lowerGroups = lower, MainGroups = main });
                    }
                    else
                    {
                        //---------STOK EKLEME--------



                        await stockService.CreatStockAsync(stockAddViewModel);

                        toast.AddSuccessToastMessage("Ürünü Ekleme Başarılı", new ToastrOptions() { Title = "İşlem" });

                        return RedirectToAction("Listele", "Product");




                    }
                }



            }
            else
            {
                // fluent validations Gösterimi
                resualt.AddToModelState(this.ModelState);




            }




            return View(new StockAddViewModel { lowerGroups = lower, MainGroups = main });

        }





        //---------------------------------------MAİN GROUP EKLEME---------------------------------------------------


        [HttpPost]
        public async Task<IActionResult> AddMainGroup(StockAddViewModel stockAddViewModel)
        {

            //---------MAİN GROUP EKLEME--------
            await mainGroupService.CreatMainGroupAsync(stockAddViewModel);

            return RedirectToAction("Index");


        }




        //---------------------------------------LOWER GROUP EKLEME---------------------------------------------------


        [HttpPost]
        public async Task<IActionResult> AddLowerGroup(StockAddViewModel stockAddViewModel)
        {
            //---------LOWER GROUP EKLEME--------

            await lowerGroupService.CreatLowerGroupAsync(stockAddViewModel);

            return RedirectToAction("Index");
        }




        //---------------------------------------STOCK TABLODA GÖSTERME----------------------------------------------


        public async Task<IActionResult> Listele()
        {
            //---------STOKLARI GETİRME--------

            var stocks = await stockService.GetAllStocksWithMainAndLowerGroupAsync();


            return View(stocks);

        }




        //---------------------------------------STOCK GÜNCELLEME ---------------------------------------------------


        [HttpGet]
        public async Task<IActionResult> Update(Guid StockId)
        {
            //---------MAİN VE LOWER GROUP GERİME--------

            var lower = await lowerGroupService.GetAllLowerGroup();
            var main = await mainGroupService.GetAllMainGroups();

            //---------STOK GETİRME--------
            var stock = await stockService.GetStocksWithMainAndLowerGroupAndIdAsync(StockId);


            //---------MAPLEME--------
            var map = mapper.Map<StockUpdateViewModel>(stock);
            map.MainGroups = main;
            map.lowerGroups = lower;

            return View(map);

        }




        //---------------------------------------STOCK GÜNCELLEME  POST---------------------------------------------------

        [HttpPost]

        public async Task<IActionResult> Update(StockUpdateViewModel stockUpdateViewModel)
        {

            //---------STOK GÜNCELLEME--------

            await stockService.UpdateStockAsync(stockUpdateViewModel);



            return RedirectToAction("Listele", "Product");
        }






        //---------------------------------------STOCK SİLME ---------------------------------------------------


        public async Task<IActionResult> Delete(Guid StockId)
        {

            //---------STOK SİLME--------

            await stockService.DeleteStockAsync(StockId);


            return RedirectToAction("Listele", "Product");
        }













        //ajax barkod kontrolü

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> HasProductName(string Barkod)
        {

            var product = await stockService.HasName(Barkod);

            if (product)
            {
                return Json("Barkod Zaten Bulunuyor.");
            }
            else
            {
                return Json(true);
            }

        }

        // ajax için lower grup getirme
        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> MainToLower(Guid id)
        {

            var lower = await lowerGroupService.GetAllLowerGroup(id);




            if (lower.Count == 0)
            {
                return Json("boş");
            }
            else
            {
                return Json(lower.ToList());
            }

        }
        // ajax için lower grup getirme
        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> LowerToStocks(Guid id)
        {

            var stocks = await stockService.GetAllStocksWithLowerIdAsync(id);




            if (stocks.Count == 0)
            {
                return Json("boş");
            }
            else
            {
                return Json(stocks.ToList());
            }

        }


        //ajax barkod kontrolü

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> HasProduct(string Barkod)
        {

            var product = await stockService.GetAllStocksWithBarkodAsync(Barkod);

            if (product == null)
            {
                return Json(" ");
            }
            else
            {
                return Json(product.SatisFiyat.ToString());
            }








        }
    }
}
