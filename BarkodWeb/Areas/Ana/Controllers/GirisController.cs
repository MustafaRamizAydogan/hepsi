using AutoMapper;
using BarkodWeb.Data.UnitOfWorks;
using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.Users;
using BarkodWeb.Service.Extensions;
using BarkodWeb.Service.Services.Abstractions;
using BarkodWeb.Service.Services.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BarkodWeb.Areas.Ana.Controllers
{
    [AllowAnonymous]
    [Area("Ana")]
    public class GirisController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMapper mapper;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IShopService shopService;
        

        public GirisController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, RoleManager<AppRole> roleManager,IShopService shopService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.roleManager = roleManager;
            this.shopService = shopService;
         
        }




        //---------------------------------------GİRİŞ YAPMA---------------------------------------------------

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        //---------------------------------------GİRİŞ YAPMA POST---------------------------------------------------


        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {


                //---------KULLANICI GETİRME--------
                var user = await userManager.FindByEmailAsync(userLoginViewModel.Email);



                //---------KULLANICI KONTROL--------
                if (user != null)
                {


                    //---------KULLANICI GİRİŞ YAPMA--------
                    var resualt = await signInManager.PasswordSignInAsync(user, userLoginViewModel.Password, userLoginViewModel.RememberMe, false);



                    //---------KULLANICI GİRİŞ YAPMA KONTROL--------
                    if (resualt.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "" });

                    }
                    else
                    {
                        ModelState.AddModelError("", "eposta veya şifre yanlıştır.");
                        return View();
                    }


                }
                else
                {
                    ModelState.AddModelError("", "eposta veya şifre yanlıştır.");
                    return View();
                }




            }
            else
            {
                return View();
            }

        }




        //---------------------------------------CIKIŞ YAPMA ---------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> Cikis()
        {

            //---------KULLANICI CIKIŞ YAPMA--------
            await signInManager.SignOutAsync();


            return RedirectToAction("Index", "Anasayfa", new { Area = "Ana" });
        }





        //---------------------------------------ÜYE OLMA---------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> UyeOl()
        {

            return View();
        }




        //---------------------------------------ÜYE OLMA POST---------------------------------------------------

        [HttpPost]
        public async Task<IActionResult> UyeOL(UserSingupVİewModel userSingupVİewModel)
        {



            //---------MAPLAME--------
            var map = mapper.Map<AppUser>(userSingupVİewModel);

            if (ModelState.IsValid)
            {

                map.UserName = userSingupVİewModel.Email;

                await shopService.CreatShopAsync(userSingupVİewModel.ShopName.ToUpper());
                var shop = await shopService.GetShopWithNameAsync(userSingupVİewModel.ShopName);
                
                map.ShopId = Guid.Parse(shop);

                //---------KULLANICI ÜYE OLMA--------
                var resualt = await userManager.CreateAsync(map, string.IsNullOrEmpty(userSingupVİewModel.Password) ? "" : userSingupVİewModel.Password);

                var user = userManager.Users.Where(x => x.Email == userSingupVİewModel.Email).SingleOrDefault();

                await shopService.Update(userSingupVİewModel.ShopName.ToUpper(),user.Id);

                if (resualt.Succeeded)
                {


                    //---------KULLANICI ROLÜ BULMA--------
                    var findRole = await roleManager.FindByIdAsync("cbefda7b-7761-42c4-aa47-40c7ed3d04a1");  /* FindByNameAsync("magazasahibi");*/



                    //---------KULLANICIYA ROLÜ EKLEME--------
                    await userManager.AddToRoleAsync(user, findRole.ToString());



                    //---------KULLANICI GİRİŞ YAPMA--------
                    var resualt1 = await signInManager.PasswordSignInAsync(userSingupVİewModel.Email, userSingupVİewModel.Password, false, false);


                    if (resualt1.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "" });
                    }



                }
                else
                {
                    foreach (var item in resualt.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }

            }

            return View();


        }
    }
}
