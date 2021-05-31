using AppFiscDf.Application.Model.Enum;
using AppFiscDf.Application.Model.Enum.Helper;
using AppFiscDf.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AppFiscDf.Domain.Validators
{
    public class InsDocAttachmentPostValidator : AbstractValidator<InsDocAttachment>
    {
        public InsDocAttachmentPostValidator(string method)
        {
            if (method == HttpMethods.Post)
            {
                RuleFor(x => x.InspectionDocumentId)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                    .GreaterThan(0).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustGreaterThanZero));

                RuleFor(x => x.Name)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                    .Must(x => x != null && Functions.GetFileExtension(x)).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FileExtensionInvalid))
                    .Must(x => Functions.GetCountString(x) >= 5).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldBelowMinimalCharacters) + " (5 caracteres)");

                RuleFor(x => x.AttachmentFile)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                    .Must(x => x != null && x.Length > 1 && x.Length <= 200000000).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FileLargerThanAllowed));
            }
        }
    }
}