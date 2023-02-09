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
            //Rule for GenerateTime
            RuleFor(post=>post.GenerateTime).NotEmpty().WithMessage("GenerateTime boş bırakılamaz.");

            ////Rule for Content
            //RuleFor(post=>post.PostContent).NotEmpty().WithMessage("Content boş bırakılamaz.");
            //RuleFor(post=>post.PostContent).MaximumLength(300).WithMessage("Maximum 300 karakter girilmelidir!");
            //RuleFor(post => post.PostContent).MinimumLength(2).WithMessage("Minimum 2 karakter girilmelidir!");

            //Rule for Description
            RuleFor(post=>post.Description).MaximumLength(300).WithMessage("Maximum 300 karakter girilmelidir!");

            //Rule for CreatorUser
            //RuleFor(post => post.Creator.NickName).NotNull().WithMessage("User seçiniz!");
            //RuleFor(post => post.Genre).NotNull().WithMessage("Type seçiniz!");
            //RuleFor(post => post.Creator.NickName).NotNull().WithMessage("User seçiniz!");
            //RuleFor(post => post.Creator.NickName).Null().WithMessage("User seçiniz!");

        }
    }
}
