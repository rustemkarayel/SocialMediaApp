using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator() 
        {
            //Rule for FirstName
            RuleFor(user => user.FirstName).NotEmpty().WithMessage("FirstName boş bırakılamaz!");
            RuleFor(user => user.FirstName).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir!");   
            
            //Rule for LastName
            RuleFor(user=>user.LastName).NotEmpty().WithMessage("LastName boş bırakılamaz!");
            RuleFor(user => user.LastName).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir!");

            //Rule for NickName
            RuleFor(user => user.NickName).NotEmpty().WithMessage("NickName boş bırakılamaz!");
            RuleFor(user => user.NickName).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir!");
            RuleFor(user => user.NickName).MinimumLength(2).WithMessage("Minimum 2 karakter girilmelidir!");
            //Rule for Password
            RuleFor(user => user.Password).NotEmpty().WithMessage("Password boş bırakılamaz!");
            RuleFor(user => user.Password).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir!");
            RuleFor(user => user.Password).MinimumLength(4).WithMessage("Minimum 4 karakter girilmelidir!");

            //Rule for Birthday
            RuleFor(user => user.Birthday).NotEmpty().WithMessage("Birthday boş bırakılamaz!");

            //Rule for PhotoUrl
            RuleFor(user => user.PhotoUrl).NotEmpty().WithMessage("PhotoUrl boş bırakılamaz!");
            RuleFor(user => user.PhotoUrl).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir!");

            //Rule for Mail
            RuleFor(user => user.Mail).NotEmpty().WithMessage("Mail boş bırakılamaz!");
            RuleFor(user => user.Mail).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir!");

            //Rule for Phone
            RuleFor(user => user.Phone).NotEmpty().WithMessage("Phone boş bırakılamaz!");
            RuleFor(user => user.Phone).MaximumLength(11).WithMessage("Maximum 11 karakter girilmelidir!");
            RuleFor(user => user.Phone).MinimumLength(11).WithMessage("Minimum 11 karakter girilmelidir!");

            //Rule for Country
            RuleFor(user => user.Country).NotEmpty().WithMessage("Country boş bırakılamaz!");
            RuleFor(user => user.Country).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir!");

            //Rule for Gender
            RuleFor(user => user.Gender).NotEmpty().WithMessage("Gender boş bırakılamaz!");

            //Rule for IsActive
            RuleFor(user => user.IsActive).NotEmpty().WithMessage("IsActive boş bırakılamaz!");
        }
    }
}
