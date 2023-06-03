using BarkodWeb.Data.UnitOfWorks;
using BarkodWeb.Entity.Entities;
using BarkodWeb.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Service.Services.Concretes
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public AppUserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        //public async Task GetUserToShowId (Guid Id)
        //{
        //   var userData= await unitOfWork.GetRepository<AppUser>().GetByGuidAsync(Id);

        //    return 0;
        //}
    }
}
