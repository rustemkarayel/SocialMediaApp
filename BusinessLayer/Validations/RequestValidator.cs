using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class RequestValidator:AbstractValidator<Request>
    {
        public RequestValidator()
        {
            //Rule for RequestState
            RuleFor(request=>request.RequestTime).NotEmpty().WithMessage("RequestState boş bırakılamaz.");

            //Rule for RequestState
            RuleFor(request => request.RequestState).NotEmpty().WithMessage("RequestState boş bırakılamaz.");

            //Rule for IsActive
            RuleFor(request => request.IsActive).NotEmpty().WithMessage("IsActive boş bırakılamaz.");
        }
    }
}
