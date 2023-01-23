using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class AdminValidator:AbstractValidator<Admin>
    {
        public AdminValidator() 
        {
            //Rule for AdminFirstName
            RuleFor(admin => admin.AdminFirstName).NotEmpty().WithMessage("FirstName boş bırakılamaz!");
            RuleFor(admin => admin.AdminFirstName).MaximumLength(30).WithMessage("Maximum 30 karakter girilmelidir!");

            //Rule for AdminLastName
            RuleFor(admin => admin.AdminLastName).NotEmpty().WithMessage("LastName boş bırakılamaz!");
            RuleFor(admin => admin.AdminLastName).MaximumLength(30).WithMessage("Maximum 30 karakter girilmelidir!");

            //Rule for AdminMail
            RuleFor(admin => admin.AdminMail).NotEmpty().WithMessage("Mail boş bırakılamaz!");
            RuleFor(admin => admin.AdminMail).MaximumLength(30).WithMessage("Maximum 30 karakter girilmelidir!");

            //Rule for AdminPassword
            RuleFor(admin => admin.AdminPassword).NotEmpty().WithMessage("Password boş bırakılamaz!");
            RuleFor(admin => admin.AdminPassword).MaximumLength(15).WithMessage("Maximum 15 karakter girilmelidir!");
            RuleFor(admin => admin.AdminPassword).MinimumLength(4).WithMessage("Minimum 4 karakter girilmelidir!");

            //Rule for AdminType
            RuleFor(admin => admin.AdminType).NotEmpty().WithMessage("AdminType boş bırakılamaz!");
            RuleFor(admin => admin.AdminType).MaximumLength(15).WithMessage("Maximum 15 karakter girilmelidir!");

            //Rule for imgUrl
            RuleFor(admin => admin.imgUrl).NotEmpty().WithMessage("Img Url boş bırakılamaz!");
            RuleFor(admin => admin.imgUrl).MaximumLength(100).WithMessage("Maximum 100 karakter girilmelidir!");
        }
    }
}
