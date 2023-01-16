using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FluentValidation;

namespace BusinessLayer.Validations
{
    public class GenreValidator:AbstractValidator<Genre>
    {
        public GenreValidator()
        {
            //Name
            RuleFor(genre=>genre.GenreName).NotEmpty().WithMessage("Name alanı boş geçilemez !");
            RuleFor(genre=>genre.GenreName).MaximumLength(25).WithMessage("Name alanı maksimum 25 karakter olmalı !");
        }
    }
}
