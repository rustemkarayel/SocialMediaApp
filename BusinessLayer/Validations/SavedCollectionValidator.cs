using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class SavedCollectionValidator:AbstractValidator<SavedCollection>
    {
        public SavedCollectionValidator() 
        {
            //Rule for IsActive
            RuleFor(savedCollection => savedCollection.IsActive).NotEmpty().WithMessage("IsActive boş bırakılamaz!");
        }
    }
}
