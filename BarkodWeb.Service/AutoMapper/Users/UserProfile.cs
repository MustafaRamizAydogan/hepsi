using AutoMapper;
using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.Stocks;
using BarkodWeb.Entity.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Service.AutoMapper.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserViewModel, AppUser>().ReverseMap();
            CreateMap<UserAddViewModel, AppUser>().ReverseMap();
            CreateMap<UserSingupVİewModel, AppUser>().ReverseMap();
           
        }
    }
    
}
