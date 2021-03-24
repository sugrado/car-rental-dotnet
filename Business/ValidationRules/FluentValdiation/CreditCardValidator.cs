using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValdiation
{
    public class CreditCardValidator: AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(p => p.CardHolder).NotEmpty();
            RuleFor(p => p.CardNumber).NotEmpty();
            RuleFor(p => p.CvvCode).NotEmpty();
            RuleFor(p => p.ExpirationDate).NotEmpty();
        }
    }
}
