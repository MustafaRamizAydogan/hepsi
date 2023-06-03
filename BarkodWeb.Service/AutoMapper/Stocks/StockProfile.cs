using AutoMapper;
using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Service.AutoMapper.Stocks
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<StockViewModel, Stock>().ReverseMap();
          
            CreateMap<StockUpdateViewModel, Stock>().ReverseMap();

            CreateMap<StockUpdateViewModel, StockViewModel>().ReverseMap();

            CreateMap<StockAddViewModel, Stock>().ReverseMap();
        }
    }
}
