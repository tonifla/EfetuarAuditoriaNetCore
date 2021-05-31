using AppFiscDf.Application.Model.Enum;
using AppFiscDf.Application.Model.Enum.Helper;
using AppFiscDf.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AppFiscDf.Domain.Validators
{
    public class InspectionDocumentDeleteValidator : AbstractValidator<InspectionDocument>
    {
        public InspectionDocumentDeleteValidator(string method)
        {
            if (method == HttpMethods.Delete)
            {
                RuleForEach(x => x.InsDocInspectionAgentList)
                .ChildRules(InsDocInspectionAgent =>
                {
                    InsDocInspectionAgent
                    .RuleFor(x => x.InspectionAgentId)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                    .GreaterThan(0).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustGreaterThanZero));
                });

                RuleFor(x => x.InspectionDocumentId)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                    .GreaterThan(0).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustGreaterThanZero));

                RuleFor(x => x.EndDate)
                    .Null().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileDeletingInspectionDocumentFinished));
            }
        }
    }
}