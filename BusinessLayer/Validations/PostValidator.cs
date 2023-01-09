using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class PostValidator:AbstractValidator<Post>
    {
        public PostValidator()
        {
            //Rule for GenerateDate
            RuleFor(post=>post.GenerateDate).NotEmpty().WithMessage("GenerateDate boş bırakılamaz.");

            //Rule for Content
            RuleFor(post=>post.Content).NotEmpty().WithMessage("Content boş bırakılamaz.");
            RuleFor(post=>post.Content).MaximumLength(300).WithMessage("Maximum 300 karakter girilmelidir!");
            RuleFor(post => post.Content).MinimumLength(2).WithMessage("Minimum 2 karakter girilmelidir!");

            //Rule for Description
            RuleFor(post=>post.Description).NotEmpty().WithMessage("Description boş geçilemez.");
            RuleFor(post=>post.Description).MaximumLength(300).WithMessage("Maximum 300 karakter girilmelidir!");
            RuleFor(post=>post.Description).MinimumLength(2).WithMessage("Minimum 2 karakter girilmelidir!");

            //Rule for IsActive
            RuleFor(post=>post.IsActive).NotEmpty().WithMessage("IsActive boş bırakılamaz.");
        }
    }
}
