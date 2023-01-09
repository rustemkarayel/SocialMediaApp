using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class PostLikeValidator:AbstractValidator<PostLike>
    {
        public PostLikeValidator()
        {
            //Rule for LikeTime
            RuleFor(postlike=>postlike.LikeTime).NotEmpty().WithMessage("LikeTime boş bırakılamaz.");

            //Rule for IsActive
            RuleFor(postlike=>postlike.IsActive).NotEmpty().WithMessage("IsActive boş bırakılamaz.");
        }        
    }
}
