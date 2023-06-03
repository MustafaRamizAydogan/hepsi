using AutoMapper;
using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.Sales;
using BarkodWeb.Entity.ViewModels.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Service.AutoMapper.Sales
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {

            CreateMap<SaleAddViewModel, Sale>().ReverseMap();

        }
    }
}
