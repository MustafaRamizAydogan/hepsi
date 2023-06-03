using AutoMapper;
using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.LowerGroups;
using BarkodWeb.Entity.ViewModels.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Service.AutoMapper.LowerGroups
{
    public class LowerGroupProfile : Profile
    {
        public LowerGroupProfile()
        {
            CreateMap<LowerGroupViewModel,LowerGroup>().ReverseMap();
        }
    }
}
