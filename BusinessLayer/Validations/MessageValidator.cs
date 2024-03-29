﻿using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            //Rule for Content
            RuleFor(message => message.MessageContent).NotEmpty().WithMessage("Content boş bırakılamaz!");
            RuleFor(message => message.MessageContent).MaximumLength(100).WithMessage("Maximum 100 karakter girilmelidir!");

            //Rule for SendDate
            RuleFor(message => message.SendDate).NotEmpty().WithMessage("SendDate boş bırakılamaz!");

            //Rule for SendTime
            RuleFor(message => message.SendTime).NotEmpty().WithMessage("SendTime boş bırakılamaz!");

        }
    }
}
