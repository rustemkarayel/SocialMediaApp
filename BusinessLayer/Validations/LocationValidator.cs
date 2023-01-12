using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class LocationValidator:AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(location=>location.LocationName).NotEmpty().WithMessage("Lokasyon ismi boş geçilemez !");
        }
    }
}
