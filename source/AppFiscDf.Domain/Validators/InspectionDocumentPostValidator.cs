using AppFiscDf.Application.Model.Enum;
using AppFiscDf.Application.Model.Enum.Helper;
using AppFiscDf.Application.Model.RequestResponse;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AppFiscDf.Domain.Validators
{
    public class InspectionDocumentPostValidator : AbstractValidator<InspectionDocumentRequestResponse>
    {
        public InspectionDocumentPostValidator(string method)
        {
            if (method == HttpMethods.Post)
            {
                RuleFor(x => x.InspectionDocumentId)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .GreaterThan(-1).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.IsRequiredForTheFilter));

                RuleFor(x => x.UfReference)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty));

                RuleFor(x => x.SequentialCode)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                    .GreaterThan(0).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustGreaterThanZero))
                    .Must(x => Functions.GetCountString(x.ToString()) == 6).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustHaveCorrectNumberCharacters) + " (6 caracteres)");

                RuleFor(x => x.DocumentNumber)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                    .Must(x => Functions.GetCountString(x) == 16).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustHaveCorrectNumberCharacters) + " (16 caracteres)");

                RuleFor(x => x.InsDocEconomicAgentRequestResponses.InspectionDocumentId)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .GreaterThan(-1).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.IsRequiredForTheFilter));

                RuleFor(x => x.InsDocEconomicAgentRequestResponses.UfReference)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty));

                RuleFor(x => x.InsDocEconomicAgentRequestResponses.ActivityId)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty));

                RuleFor(x => x.InsDocEconomicAgentRequestResponses.CpfCnpj)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                    .Must(x => Functions.GetCountString(x) == 11 || Functions.GetCountString(x) == 14).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustHaveCorrectNumberCharacters) + " (CPF - 11 / CNPJ - 14)");

                RuleFor(x => x.InsDocEconomicAgentRequestResponses.Email)
                    .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                    .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                    .EmailAddress().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.EmailMustValid));

                RuleForEach(x => x.InsDocInspectionAgentRequestResponses)
                    .ChildRules(InsDocInspectionAgentRequestResponse =>
                    {
                        InsDocInspectionAgentRequestResponse
                        .RuleFor(x => x.InspectionAgentId)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                        .GreaterThan(0).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustGreaterThanZero));
                    });

                RuleForEach(x => x.InsDocInspectionAgentRequestResponses)
                    .ChildRules(InsDocInspectionAgentRequestResponse =>
                    {
                        InsDocInspectionAgentRequestResponse
                        .RuleFor(x => x.InspectionDocumentId)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .GreaterThan(-1).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.IsRequiredForTheFilter));
                    });

                RuleForEach(x => x.InsDocInspectionAgentRequestResponses)
                    .ChildRules(InsDocInspectionAgentRequestResponse =>
                    {
                        InsDocInspectionAgentRequestResponse
                        .RuleFor(x => x.Sort)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                        .GreaterThan(0).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustGreaterThanZero));
                    });

                RuleFor(x => x.InsDocInspectionAgentRequestResponses)
                  .Must(x => x.Count >= 1).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.ListCannotNull));

                RuleFor(x => x.InsDocRepresentativeRequestResponses.InspectionDocumentId)
                  .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                  .GreaterThan(-1).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.IsRequiredForTheFilter));

                RuleFor(x => x.InsDocRepresentativeRequestResponses.Name)
                  .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                  .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty));

                RuleFor(x => x.InsDocRepresentativeRequestResponses.Document)
                  .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                  .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty));

                RuleFor(x => x.InsDocRepresentativeRequestResponses.Employment)
                  .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                  .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty));

                RuleFor(x => x.InsDocRepresentativeRequestResponses.SignatureDate)
                  .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                  .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty));

                RuleFor(x => x.InsDocRepresentativeRequestResponses.SignatureImage)
                  .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                  .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty));

                RuleForEach(x => x.InsDocTypificationRequestResponses)
                    .ChildRules(InsDocTypificationRequestResponse =>
                    {
                        InsDocTypificationRequestResponse
                        .RuleFor(x => x.InsDocTypificationId)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .GreaterThan(-1).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.IsRequiredForTheFilter));
                    });

                RuleForEach(x => x.InsDocTypificationRequestResponses)
                    .ChildRules(InsDocTypificationRequestResponse =>
                    {
                        InsDocTypificationRequestResponse
                        .RuleFor(x => x.TypificationId)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                        .GreaterThan(0).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustGreaterThanZero));
                    });

                RuleForEach(x => x.InsDocTypificationRequestResponses)
                    .ChildRules(InsDocTypificationRequestResponse =>
                    {
                        InsDocTypificationRequestResponse
                        .RuleFor(x => x.InspectionDocumentId)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .GreaterThan(-1).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.IsRequiredForTheFilter));
                    });

                RuleForEach(x => x.InsDocTypificationRequestResponses)
                    .ChildRules(InsDocTypificationRequestResponse =>
                    {
                        InsDocTypificationRequestResponse
                        .RuleFor(x => x.JsonOutput)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty));
                    });

                RuleForEach(x => x.InsDocTypificationRequestResponses)
                    .ChildRules(InsDocTypificationRequestResponse =>
                    {
                        InsDocTypificationRequestResponse
                        .RuleFor(x => x.FreeText)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull));
                    });

                RuleForEach(x => x.InsDocWitnessRequestResponses)
                    .ChildRules(InsDocWitnessRequestResponse =>
                    {
                        InsDocWitnessRequestResponse
                        .RuleFor(x => x.InsDocWitnessId)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .GreaterThan(-1).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.IsRequiredForTheFilter));
                    });

                RuleForEach(x => x.InsDocWitnessRequestResponses)
                    .ChildRules(InsDocWitnessRequestResponse =>
                    {
                        InsDocWitnessRequestResponse
                        .RuleFor(x => x.InspectionDocumentId)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .GreaterThan(-1).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.IsRequiredForTheFilter));
                    });

                RuleForEach(x => x.InsDocWitnessRequestResponses)
                    .ChildRules(InsDocWitnessRequestResponse =>
                    {
                        InsDocWitnessRequestResponse
                        .RuleFor(x => x.Name)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty));
                    });

                RuleForEach(x => x.InsDocWitnessRequestResponses)
                    .ChildRules(InsDocWitnessRequestResponse =>
                    {
                        InsDocWitnessRequestResponse
                        .RuleFor(x => x.Document)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty));
                    });

                RuleForEach(x => x.InsDocWitnessRequestResponses)
                    .ChildRules(InsDocWitnessRequestResponse =>
                    {
                        InsDocWitnessRequestResponse
                        .RuleFor(x => x.Employment)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty));
                    });

                RuleForEach(x => x.InsDocWitnessRequestResponses)
                    .ChildRules(InsDocWitnessRequestResponse =>
                    {
                        InsDocWitnessRequestResponse
                        .RuleFor(x => x.SignatureDate)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty));
                    });

                RuleForEach(x => x.InsDocWitnessRequestResponses)
                    .ChildRules(InsDocWitnessRequestResponse =>
                    {
                        InsDocWitnessRequestResponse
                        .RuleFor(x => x.SignatureImage)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty));
                    });

                RuleFor(x => x.InsDocWitnessRequestResponses)
                  .Must(x => x.Count <= 2).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.NoMoreThan2WitnessesAreAllowed));

                RuleForEach(x => x.InsDocAttachmentRequestResponses)
                    .ChildRules(InsDocAttachmentRequestResponse =>
                    {
                        InsDocAttachmentRequestResponse
                        .RuleFor(x => x.InsDocAttachmentId)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .GreaterThan(-1).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.IsRequiredForTheFilter));
                    });

                RuleForEach(x => x.InsDocAttachmentRequestResponses)
                    .ChildRules(InsDocAttachmentRequestResponse =>
                    {
                        InsDocAttachmentRequestResponse
                        .RuleFor(x => x.InspectionDocumentId)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .GreaterThan(-1).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.IsRequiredForTheFilter));
                    });

                RuleForEach(x => x.InsDocAttachmentRequestResponses)
                    .ChildRules(InsDocAttachmentRequestResponse =>
                    {
                        InsDocAttachmentRequestResponse
                        .RuleFor(x => x.Name)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                        .Must(x => x != null && Functions.GetFileExtension(x)).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FileExtensionInvalid))
                        .Must(x => Functions.GetCountString(x) >= 5).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldBelowMinimalCharacters) + " (5 caracteres)");
                    });

                RuleForEach(x => x.InsDocAttachmentRequestResponses)
                    .ChildRules(InsDocAttachmentRequestResponse =>
                    {
                        InsDocAttachmentRequestResponse
                        .RuleFor(x => x.AttachmentFile)
                        .NotNull().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotNull))
                        .NotEmpty().WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FieldCannotEmpty))
                        .Must(x => x.Length > 1 && x.Length <= 200000000).WithMessage(Enumerations.GetDescription(SuccessAndErrorMessages.FileLargerThanAllowed));
                    });
            }
        }
    }
}