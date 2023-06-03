using BarkodWeb.Entity.ViewModels.Stocks;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Service.FluentValidations
{
    public class StockAddViewModelValidator : AbstractValidator<StockAddViewModel>
    {
        public StockAddViewModelValidator()
        {
            RuleFor(x => x.Barkod)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);
                             
            RuleFor(x => x.SatisFiyat)
                  .NotEmpty()
                .NotNull()
                .GreaterThan(y => y.AlisFiyat);
            RuleFor(x => x.AlisFiyat)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Stok)
              .NotEmpty()
              .NotNull();



        }
    }
}
