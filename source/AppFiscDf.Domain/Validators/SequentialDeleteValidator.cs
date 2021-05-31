using AppFiscDf.Application.Model.Enum;
using AppFiscDf.Application.Model.Enum.Helper;
using AppFiscDf.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AppFiscDf.Domain.Validators
{
    public class SequentialDeleteValidator : AbstractValidator<Sequential>
    {
        public SequentialDeleteValidator(string method)
        {
            if (method == HttpMethods.Delete)
            {
                RuleFor(x => x.InspectionAgentId)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                    .GreaterThan(0).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustGreaterThanZero));

                RuleFor(x => x.SequentialCode)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                    .GreaterThan(0).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustGreaterThanZero))
                    .Must(x => Functions.GetCountString(x.ToString()) == 6).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustHaveCorrectNumberCharacters) + " (6 caracteres)");

                RuleFor(x => x)
                    .Must(x => x.InspectionAgentId > 0 && x.SequentialCode > 0)
                    .WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustGreaterThanZero));
            }
        }
    }
}