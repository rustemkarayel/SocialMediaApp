using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class CommentValidator:AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            //Content
            RuleFor(comment => comment.CommentContent).NotEmpty().WithMessage("Content alanı boş geçilemez !");
            RuleFor(comment => comment.CommentContent).MaximumLength(100).WithMessage("Content alanı maksimum 100 karakter olmalı !");

            //Date
            RuleFor(comment => comment.CommentDate).NotEmpty().WithMessage("Date alanı boş geçilemez !");

            //Time
            RuleFor(comment => comment.CommentTime).NotEmpty().WithMessage("Time alanı boş geçilemez !");
        }
    }
}
