using AppFiscDf.Application.Model.Enum;
using AppFiscDf.Application.Model.Enum.Helper;
using AppFiscDf.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AppFiscDf.Domain.Validators
{
    public class InsDocAttachmentDeleteValidator : AbstractValidator<InsDocAttachment>
    {
        public InsDocAttachmentDeleteValidator(string method)
        {
            if (method == HttpMethods.Delete)
            {
                RuleFor(x => x.InspectionDocumentId)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                    .GreaterThan(0).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustGreaterThanZero));

                RuleFor(x => x.InsDocAttachmentId)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                    .GreaterThan(0).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustGreaterThanZero));
            }
        }
    }
}