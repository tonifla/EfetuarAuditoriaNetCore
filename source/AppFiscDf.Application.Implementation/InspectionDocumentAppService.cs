using AppFiscDf.Application.Interface;
using AppFiscDf.Application.Model.Enum;
using AppFiscDf.Application.Model.Enum.Helper;
using AppFiscDf.Application.Model.RequestResponse;
using AppFiscDf.Domain.Entities;
using AppFiscDf.Domain.Interface.Services;
using AppFiscDf.Domain.Interface.UnitOfWork;
using AppFiscDf.Domain.Validators;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AppFiscDf.Application.Implementation
{
    public class InspectionDocumentAppService : IInspectionDocumentAppService
    {
        private readonly IInspectionDocumentService _inspectionDocumentService;
        private readonly IUnitOfWork _unitOfWork;

        public InspectionDocumentAppService(IInspectionDocumentService inspectionDocumentService, IUnitOfWork unitOfWork)
        {
            _inspectionDocumentService = inspectionDocumentService;
            _unitOfWork = unitOfWork;
        }

        public async Task<MessageResponse<IEnumerable<InspectionDocumentRequestResponse>>> ListByInspectionDocumentAsync(bool finished, decimal inspectionAgentId, DateTime startDate, DateTime endDate, decimal sequentialCode, string cpfCnpj, string companyName)
        {
            var messageResponse = new MessageResponse<IEnumerable<InspectionDocumentRequestResponse>>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfInspectionDocument),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            //if ((startDate <= DateTime.MinValue && endDate <= DateTime.MinValue && sequentialCode <= 0 && string.IsNullOrEmpty(cpfCnpj) && string.IsNullOrEmpty(companyName))
            //    || (startDate < DateTime.MinValue && endDate <= DateTime.MinValue || startDate <= DateTime.MinValue && endDate < DateTime.MinValue))
            //{
            //    messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.RequiredField);
            //    messageResponse.IsSuccess = false;
            //}
            //else if (startDate > DateTime.MinValue || endDate > DateTime.MinValue
            //         || startDate > DateTime.UtcNow || endDate > DateTime.UtcNow
            //         || (startDate > endDate))
            //{
            //    messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.StartingNumberGreaterThanEndingNumber);
            //    messageResponse.IsSuccess = false;
            //}
            //else
            //{
                try
                {
                    var inspectionDocument = await _inspectionDocumentService.ListByInspectionDocumentAsync(finished, inspectionAgentId, startDate, endDate, sequentialCode, cpfCnpj, companyName);
                    messageResponse.Data = inspectionDocument;
                    messageResponse.Message = messageResponse.Data.Any() ? Enumerations.GetDescription(SuccessAndErrorMessages.SuccessfullyListed) : Enumerations.GetDescription(SuccessAndErrorMessages.NoDateFound);
                    messageResponse.Count = messageResponse.Data.Any() ? messageResponse.Data.Count() : 0;
                    messageResponse.IsSuccess = true;
                }
                catch (Exception e)
                {
                    messageResponse.IsSuccess = false;
                    messageResponse.Message = e.Message.ToString();
                }
            //}

            return messageResponse;
        }

        public async Task<IEnumerable<InspectionDocumentReducedResponse>> ListByInspectionDocumentAsync(decimal inspectionAgentId, bool finished)
        {
            return await _inspectionDocumentService.ListByInspectionDocumentAsync(inspectionAgentId, false);
        }

        public async Task<MessageResponse<IEnumerable<InspectionDocumentRequestResponse>>> ListByInspectionDocumentAsync(int typeInspectionDocument, decimal inspectionAgentId, DateTime startDate, DateTime endDate, decimal sequentialCode, string economicAgentCpfCnpj, string economicAgentCompanyName, decimal nrUfId, string ufAcronym, decimal orderServiceYear, decimal orderServiceNumber, int page)
        {
            var messageResponse = new MessageResponse<IEnumerable<InspectionDocumentRequestResponse>>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfInspectionDocument),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            page = page <= 1 ? 1 : page;

            if ((inspectionAgentId <= 0 && startDate <= DateTime.MinValue && endDate <= DateTime.MinValue && sequentialCode <= 0
                && string.IsNullOrEmpty(economicAgentCpfCnpj) && string.IsNullOrEmpty(economicAgentCompanyName) && nrUfId <= 0
                && string.IsNullOrEmpty(ufAcronym) && orderServiceYear <= 0 && orderServiceNumber <= 0)
                || (startDate < DateTime.MinValue && endDate <= DateTime.MinValue || startDate <= DateTime.MinValue && endDate < DateTime.MinValue))
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.RequiredField);
                messageResponse.IsSuccess = false;
            }
            else if (typeInspectionDocument != 0 && typeInspectionDocument != 1 && typeInspectionDocument != 2)
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.IsRequiredForTheFilter);
                messageResponse.IsSuccess = false;
            }
            else if (startDate > DateTime.MinValue || endDate > DateTime.MinValue
                     || startDate > DateTime.UtcNow || endDate > DateTime.UtcNow
                     || (startDate > endDate))
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.StartingNumberGreaterThanEndingNumber);
                messageResponse.IsSuccess = false;
            }
            else
            {
                try
                {
                    var inspectionDocument = await _inspectionDocumentService.ListByInspectionDocumentAsync(typeInspectionDocument, inspectionAgentId, startDate, endDate, sequentialCode, economicAgentCpfCnpj, economicAgentCompanyName, nrUfId, ufAcronym, orderServiceYear, orderServiceNumber, page);
                    messageResponse.Data = inspectionDocument;
                    messageResponse.Message = messageResponse.Data.Any() ? Enumerations.GetDescription(SuccessAndErrorMessages.SuccessfullyListed) : Enumerations.GetDescription(SuccessAndErrorMessages.NoDateFound);
                    messageResponse.Count = messageResponse.Data.Any() ? messageResponse.Data.Count() : 0;
                    messageResponse.Page = page;
                    messageResponse.IsSuccess = true;
                }
                catch (Exception e)
                {
                    messageResponse.IsSuccess = false;
                    messageResponse.Message = e.Message.ToString();
                }
            }

            return messageResponse;
        }

        public async Task<InspectionDocumentRequestResponse> FindByInspectionDocumentAsync(decimal inspectionDocumentId)
        {
            return await _inspectionDocumentService.FindByInspectionDocumentAsync(inspectionDocumentId);
        }

        public async Task<MessageResponse<InspectionDocumentRequestResponse>> FindByInspectionDocumentAsync(decimal inspectionAgentId, decimal sequentialCode, bool finished)
        {
            var messageResponse = new MessageResponse<InspectionDocumentRequestResponse>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfInspectionDocument),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            if (inspectionAgentId <= 0 || sequentialCode <= 0)
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustGreaterThanZero);
                messageResponse.IsSuccess = false;
            }
            else
            {
                try
                {
                    var inspectionDocument = await _inspectionDocumentService.FindByInspectionDocumentAsync(inspectionAgentId, sequentialCode, finished);
                    messageResponse.Data = inspectionDocument;
                    messageResponse.Message = (messageResponse.Data != null) ? Enumerations.GetDescription(SuccessAndErrorMessages.SuccessfullyFinded) : Enumerations.GetDescription(SuccessAndErrorMessages.NoDateFound);
                    messageResponse.IsSuccess = true;
                }
                catch (Exception e)
                {
                    messageResponse.IsSuccess = false;
                    messageResponse.Message = e.Message.ToString();
                }
            }

            return messageResponse;
        }

        public async Task<InspectionDocumentRequestResponse> InsertInspectionDocumentAsync(InspectionDocumentRequestResponse request)
        {
            InspectionDocumentRequestResponse inspectionDocumentInsert = null;

            var messageResponse = new MessageResponse<InspectionDocumentRequestResponse>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.SaveInspectionDocument),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            var inspectionDocumentValidator = new InspectionDocumentPostValidator(request.EndDate != null ? HttpMethods.Post : null);

            //var validatorResult = inspectionDocumentValidator.Validate(request);
            //var inconsistencies = new List<Inconsistencies>(validatorResult.Errors.Count);

            //if (!validatorResult.IsValid)
            //{
            //    foreach (var error in validatorResult.Errors)
            //    {
            //        inconsistencies.Add(new Inconsistencies
            //        {
            //            Field = error.PropertyName,
            //            Description = error.ErrorMessage
            //        });
            //    }
            //}

            //if (request.InspectionDocumentId > 0)
            //{
            //    var inspectionDocumentFinished = await _inspectionDocumentService.FindByInspectionDocumentAsync(request.InspectionDocumentId);
            //    if (inspectionDocumentFinished.EndDate != null)
            //    {
            //        inconsistencies.Add(new Inconsistencies
            //        {
            //            Field = "InspectionDocumentFinished",
            //            Description = Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileSavingInspectionDocumentFinished)
            //        });
            //    }
            //}

            //messageResponse.Inconsistencies = inconsistencies.ToArray();

            //if (inconsistencies.Count > 0)
            //{
            //    messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileSaving);
            //    messageResponse.IsSuccess = false;
            //}
            //else
            //{
                try
                {
                    inspectionDocumentInsert = await _inspectionDocumentService.InsertInspectionDocumentAsync(request);
                    messageResponse.IsSuccess = true;
                }
                catch (Exception e)
                {
                    messageResponse.Message = e.Message.ToString();
                    messageResponse.IsSuccess = false;
                }
            //}

            if (messageResponse.IsSuccess)
            {
                var result = await _unitOfWork.CompletedAsync();
                messageResponse.Message = result ?
                        Enumerations.GetDescription(SuccessAndErrorMessages.SuccessfullySaved)
                        : Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileSaving);
            }

            return inspectionDocumentInsert;
        }

        public async Task<InspectionDocumentRequestResponse> UpdateInspectionDocumentAsync(InspectionDocumentRequestResponse request)
        {
            InspectionDocumentRequestResponse inspectionDocumentUpdate = null;

            var messageResponse = new MessageResponse<InspectionDocumentRequestResponse>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.SaveInspectionDocument),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            var inspectionDocumentValidator = new InspectionDocumentPostValidator(request.EndDate != null ? HttpMethods.Post : null);

            //var validatorResult = inspectionDocumentValidator.Validate(request);
            //var inconsistencies = new List<Inconsistencies>(validatorResult.Errors.Count);

            //if (!validatorResult.IsValid)
            //{
            //    foreach (var error in validatorResult.Errors)
            //    {
            //        inconsistencies.Add(new Inconsistencies
            //        {
            //            Field = error.PropertyName,
            //            Description = error.ErrorMessage
            //        });
            //    }
            //}

            //if (request.InspectionDocumentId > 0)
            //{
            //    var inspectionDocumentFinished = await _inspectionDocumentService.FindByInspectionDocumentAsync(request.InspectionDocumentId);
            //    if (inspectionDocumentFinished.EndDate != null)
            //    {
            //        inconsistencies.Add(new Inconsistencies
            //        {
            //            Field = "InspectionDocumentFinished",
            //            Description = Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileSavingInspectionDocumentFinished)
            //        });
            //    }
            //}

            //messageResponse.Inconsistencies = inconsistencies.ToArray();

            //if (inconsistencies.Count > 0)
            //{
            //    messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileSaving);
            //    messageResponse.IsSuccess = false;
            //}
            //else
            //{
                try
                {
                    inspectionDocumentUpdate = await _inspectionDocumentService.UpdateInspectionDocumentAsync(request);
                    messageResponse.IsSuccess = true;
                }
                catch (Exception e)
                {
                    messageResponse.Message = e.Message.ToString();
                    messageResponse.IsSuccess = false;
                }
            //}

            if (messageResponse.IsSuccess)
            {
                var result = await _unitOfWork.CompletedAsync();
                messageResponse.Message = result ?
                        Enumerations.GetDescription(SuccessAndErrorMessages.SuccessfullySaved)
                        : Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileSaving);
            }

            return inspectionDocumentUpdate;
        }

        public async Task<InspectionDocumentRequestResponse> DeleteInspectionDocumentAsync(decimal inspectionAgentId, decimal inspectionDocumentId)
        {
            InspectionDocumentRequestResponse inspectionDocumentDelete = null;

            var messageResponse = new MessageResponse<InspectionDocumentRequestResponse>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.DeleteInspectionDocument),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            var inspectionDocumentValidator = new InspectionDocumentDeleteValidator(HttpMethods.Delete);

            var inspectionDocument = new InspectionDocument();
            var insDocInspectionAgent = new InsDocInspectionAgent();

            inspectionDocument.InspectionDocumentId = inspectionDocumentId;
            insDocInspectionAgent.InspectionAgentId = inspectionAgentId;

            var validatorResult = inspectionDocumentValidator.Validate(inspectionDocument);
            var inconsistencies = new List<Inconsistencies>(validatorResult.Errors.Count);

            if (!validatorResult.IsValid)
            {
                foreach (var error in validatorResult.Errors)
                {
                    inconsistencies.Add(new Inconsistencies
                    {
                        Field = error.PropertyName,
                        Description = error.ErrorMessage
                    });
                }
            }

            var inspectionDocumentType = await _inspectionDocumentService.FindByInspectionDocumentAsync(inspectionDocumentId);
            if (inspectionDocumentType != null)
            {
                if (inspectionDocumentType.EndDate != null)
                {
                    inconsistencies.Add(new Inconsistencies
                    {
                        Field = "InspectionDocumentFinished",
                        Description = Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileDeletingInspectionDocumentFinished)
                    });
                }
                else if (inspectionDocumentType.InsDocInspectionAgentRequestResponses.Count > 0 &&
                         inspectionDocumentType.InsDocInspectionAgentRequestResponses.ElementAt(0).InspectionAgentId == inspectionAgentId
                         && inspectionDocumentType.InsDocInspectionAgentRequestResponses.ElementAt(0).Sort != 1)
                {
                    inconsistencies.Add(new Inconsistencies
                    {
                        Field = "InspectionAgentId and Sort",
                        Description = Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileDeletingInspectionDocumentInspectionSecundary)
                    });
                }
            }
            else
            {
                inconsistencies.Add(new Inconsistencies
                {
                    Field = "InspectionDocumentInEdition",
                    Description = Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileDeletingNoDateFoundOrAlreadyUsed)
                });
            }

            messageResponse.Inconsistencies = inconsistencies.ToArray();

            if (inconsistencies.Count > 0)
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileDeleting);
                messageResponse.IsSuccess = false;
            }
            else
            {
                try
                {
                    inspectionDocumentDelete = await _inspectionDocumentService.DeleteInspectionDocumentAsync(inspectionAgentId, inspectionDocumentId);
                    messageResponse.IsSuccess = true;
                }
                catch (Exception e)
                {
                    messageResponse.Message = e.Message.ToString();
                    messageResponse.IsSuccess = false;
                }
            }

            if (messageResponse.IsSuccess)
            {
                var result = await _unitOfWork.CompletedAsync();
                messageResponse.Message = result ?
                        Enumerations.GetDescription(SuccessAndErrorMessages.SuccessfullyDeleted)
                        : Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileDeleting);
            }

            return inspectionDocumentDelete;
        }
    }
}