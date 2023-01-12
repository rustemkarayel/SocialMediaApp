using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FluentValidation;

namespace BusinessLayer.Validations
{
    public class TagValidator:AbstractValidator<Tag>
    {
        public TagValidator()
        {

            //Post kontrolü.
            RuleFor(tag=>tag.PostId).NotEmpty().WithMessage("Post boş bırakılamaz !");
            
            //User kontrolü.
            RuleFor(tag=>tag.UserId).NotEmpty().WithMessage("User boş bırakılamaz !");

            //IsActive kontrolü.
            //Pasif olarak eklenmiyor.
            //RuleFor(tag=>tag.IsActive).NotEmpty().WithMessage("IsActive boş bırakılamaz !");
        }
    }
}
