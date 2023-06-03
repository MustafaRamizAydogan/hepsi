using AutoMapper;
using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.Sales;
using BarkodWeb.Entity.ViewModels.Shops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Service.AutoMapper.Shops
{
    public class ShopProfile : Profile
    {
        public ShopProfile()
        {
            CreateMap<ShopViewModel, Shop>().ReverseMap();

        }
    }
}
