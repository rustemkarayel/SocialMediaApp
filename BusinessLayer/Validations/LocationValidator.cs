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
            //Name
            RuleFor(genre => genre.LocationName).NotEmpty().WithMessage("Name alanı boş geçilemez !");
            RuleFor(genre => genre.LocationName).MaximumLength(50).WithMessage("Name alanı maksimum 50 karakter olmalı !");
        }
    }
}
