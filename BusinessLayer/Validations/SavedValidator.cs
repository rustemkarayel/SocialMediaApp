﻿using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class SavedValidator:AbstractValidator<Saved>
    {
        public SavedValidator() 
        {
        }
    }
}
