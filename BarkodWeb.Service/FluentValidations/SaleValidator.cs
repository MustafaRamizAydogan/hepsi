using BarkodWeb.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Service.FluentValidations
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
        }
    }
}
