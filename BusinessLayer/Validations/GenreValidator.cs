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

        }
    }
}
