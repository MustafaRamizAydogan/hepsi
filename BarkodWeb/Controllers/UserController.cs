using AutoMapper;
using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.Users;
using BarkodWeb.Service.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using static System.Formats.Asn1.AsnWriter;
using System.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using BarkodWeb.Service.Extensions;
using BarkodWeb.Data.Migrations;

namespace BarkodWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IShopService shopService;
        private readonly IToastNotification toastNotification;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserController(UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, IShopService shopService, IToastNotification toastNotification, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.roleManager = roleManager;
            this.shopService = shopService;
            this.toastNotification = toastNotification;
            this.httpContextAccessor = httpContextAccessor;
        }



        //---------------------------------------KULLANICI LİSTELEME İŞLEMİ---------------------------------------------------

        public async Task<IActionResult> UserListele()
        {


            //---------USER YAKALAMA--------
            var userYakala = httpContextAccessor.HttpContext.User.GetLoggedInUserId();
            var User = await userManager.FindByIdAsync(userYakala.ToString());
            //---------KULLANICI GETİRME--------
            var users = await userManager.Users.Where(x => x.BossId == User.Id).ToListAsync();









            //---------MAPLEME İŞLEMİ--------
            var map = mapper.Map<List<UserViewModel>>(users);


            foreach (var item in map)
            {

                //---------KULLANICI TESPİT ETME--------
                var findUser = await userManager.FindByIdAsync(item.Id.ToString());


                //---------KULLANICIYA GÖRE RÖLÜ GETİRME--------
                var Role = string.Join("", await userManager.GetRolesAsync(findUser));

                //---------MAĞAZA GETİRME--------
                var shops = await shopService.GetShopWithIdAsync(item.ShopId);


                item.ShopName = shops;
                item.Role = Role;
            }


            return View(map);


        }


        //---------------------------------------KULLANICI EKLEME İŞLEMİ---------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> UserAdd()
        {
            //---------KULLANICI ROLLERİ GETİRME--------
            var roles = await roleManager.Roles.ToListAsync();


            //---------MAĞAZA GETİRME--------
            var shops = await shopService.GetAllShopAsyncWitoutModel();


            return View(new UserAddViewModel { appRoles = roles, shops = shops });
        }


        //---------------------------------------KULLANICI EKLEME İŞLEMİ POST---------------------------------------------------

        [HttpPost]
        public async Task<IActionResult> UserAdd(UserAddViewModel userAddViewModel)
        {


            //---------USER YAKALAMA--------
            var userYakala = httpContextAccessor.HttpContext.User.GetLoggedInUserId();
            var User = await userManager.FindByIdAsync(userYakala.ToString());

            //---------KULLANICI ROLLERİ GETİRME--------
            var roles = await roleManager.Roles.ToListAsync();


            //---------MAĞAZA GETİRME--------
            var shops = await shopService.GetAllShopAsyncWitoutModel();


            //---------MAPLEME İŞLEME--------
            var map = mapper.Map<AppUser>(userAddViewModel);



            if (ModelState.IsValid)
            {
                map.BossId = User.Id;
                map.UserName = userAddViewModel.Email;
                var resualt = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddViewModel.Password) ? "" : userAddViewModel.Password);


                if (resualt.Succeeded)
                {

                    //---------KULLANICI ROLLERİ GETİRME--------
                    var findRole = await roleManager.FindByIdAsync(userAddViewModel.RoleId.ToString());


                    //---------KULLANICI ROLÜ EKLEME--------
                    await userManager.AddToRoleAsync(map, findRole.ToString());


                    toastNotification.AddSuccessToastMessage("Personel Ekleme Başarılı", new ToastrOptions() { Title = "İşlem" });

                    return RedirectToAction("UserListele", "User");

                }
                else
                {

                    //---------HATALARI GETİRME--------

                    foreach (var item in resualt.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(new UserAddViewModel { appRoles = roles, shops = shops });
                }

            }

            return View();
        }

        //---------------------------------------KULLANICI SİLME İŞLEMİ---------------------------------------------------

        public async Task<IActionResult> Delete(Guid UserId)
        {

            //---------KULLANICI  GETİRME--------
            var user = await userManager.FindByIdAsync(UserId.ToString());


            //---------KULLANICI  SİLME--------
            var reualt = await userManager.DeleteAsync(user);


            //---------KULLANICI  SİLME KONTROL--------
            if (reualt.Succeeded)
            {
                toastNotification.AddSuccessToastMessage("Kullanıcı silme Başarılı", new ToastrOptions() { Title = "İşlem" });

                return RedirectToAction("UserListele", "User");

            }
            else
            {
                //---------HATALARI GETİRME--------
                foreach (var item in reualt.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return RedirectToAction("UserListele", "User");

        }





        //---------------------------------------Magaza Sahibinin shop güncelle İŞLEMİ---------------------------------------------------



        public async Task<IActionResult> Update(Guid Id)
        {

            var user = httpContextAccessor.HttpContext.User.GetLoggedInUserId();
            var UserToShop = await userManager.FindByIdAsync(user.ToString());



            UserToShop.ShopId = Id;

            await userManager.UpdateAsync(UserToShop);




            return RedirectToAction("Index", "Home");
        }

    }
}
