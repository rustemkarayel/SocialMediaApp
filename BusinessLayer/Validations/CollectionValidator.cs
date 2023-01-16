using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class CollectionValidator:AbstractValidator<Collection>
    {
        public CollectionValidator()
        {
            //Name
            RuleFor(collection=>collection.CollectionName).NotEmpty().WithMessage("Name alanı boş geçilemez !");
            RuleFor(collection=>collection.CollectionName).MaximumLength(30).WithMessage("Name alanı maksimum 30 karakterdir !");

            //Date
            RuleFor(collection => collection.CreationDate).NotEmpty().WithMessage("Date alanı boş geçilemez !");

            //Time
            RuleFor(collection => collection.CreationTime).NotEmpty().WithMessage("Time alanı boş geçilemez !");
        }
    }
}
