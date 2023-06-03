using AutoMapper;
using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.MainGroups;
using BarkodWeb.Entity.ViewModels.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Service.AutoMapper.MainGroups
{
    public class MainGroupProfile : Profile
    {
        public MainGroupProfile()
        {
            CreateMap<MainGroupViewModel, MainGroup>().ReverseMap();
        }
    }
}
