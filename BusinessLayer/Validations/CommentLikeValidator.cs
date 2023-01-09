using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class CommentLikeValidator:AbstractValidator<CommentLike>
    {
        public CommentLikeValidator()
        {
            //Rule for CommentLikeTime
            RuleFor(commentlike=>commentlike.CommentLikeTime).NotEmpty().WithMessage("CommentLikeTime boş bırakılamaz.");

            //Rule for IsActive
            RuleFor(commentlike=>commentlike.IsActive).NotEmpty().WithMessage("IsActive boş bırakılamaz.");
        }
    }
}
