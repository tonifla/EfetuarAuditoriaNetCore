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
    public class InsDocAttachmentAppService : IInsDocAttachmentAppService
    {
        private readonly IInsDocAttachmentService _insDocAttachmentService;
        private readonly IInspectionDocumentService _inspectionDocumentService;
        private readonly IUnitOfWork _unitOfWork;

        public InsDocAttachmentAppService(IInsDocAttachmentService insDocAttachmentService, IInspectionDocumentService inspectionDocumentService, IUnitOfWork unitOfWork)
        {
            _insDocAttachmentService = insDocAttachmentService;
            _inspectionDocumentService = inspectionDocumentService;
            _unitOfWork = unitOfWork;
        }

        public async Task<MessageResponse<IEnumerable<InsDocAttachmentRequestResponse>>> ListByInsDocAttachmentAsync(decimal inspectionDocumentId)
        {
            var messageResponse = new MessageResponse<IEnumerable<InsDocAttachmentRequestResponse>>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfAttachment),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            if (inspectionDocumentId < 0)
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustGreaterThanZero);
                messageResponse.IsSuccess = false;
            }
            else
            {
                try
                {
                    var inspDocAttachment = await _insDocAttachmentService.ListByInsDocAttachmentAsync(inspectionDocumentId);
                    messageResponse.Data = inspDocAttachment;
                    messageResponse.Message = messageResponse.Data.Any() ? Enumerations.GetDescription(SuccessAndErrorMessages.SuccessfullyListed) : Enumerations.GetDescription(SuccessAndErrorMessages.NoDateFound);
                    messageResponse.Count = messageResponse.Data.Any() ? messageResponse.Data.Count() : 0;
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

        public async Task<MessageResponse<InsDocAttachmentRequestResponse>> GetFileInsDocAttachmentAsync(decimal inspectionDocumentId, decimal insDocAttachmentId)
        {
            var messageResponse = new MessageResponse<InsDocAttachmentRequestResponse>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfAttachment),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            if (inspectionDocumentId < 0 && insDocAttachmentId < 0)
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustGreaterThanZero);
                messageResponse.IsSuccess = false;
            }
            else
            {
                try
                {
                    var insDocAttachment = await _insDocAttachmentService.FindByInsDocAttachmentAsync(inspectionDocumentId, insDocAttachmentId);
                    messageResponse.Data = insDocAttachment;
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

        public async Task<MessageResponse<InsDocAttachmentRequestResponse>> GetFileInsDocAttachmentAsync(string nameAttachmentInsDocFinished)
        {
            var messageResponse = new MessageResponse<InsDocAttachmentRequestResponse>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfAttachment),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            if (string.IsNullOrEmpty(nameAttachmentInsDocFinished))
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.RequiredField);
                messageResponse.IsSuccess = false;
            }
            else
            {
                try
                {
                    var insDocAttachment = await _insDocAttachmentService.FindByInsDocAttachmentAsync(nameAttachmentInsDocFinished);
                    messageResponse.Data = insDocAttachment;
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

        public async Task<MessageResponse<InsDocAttachmentRequestResponse>> InsertInsDocAttachmentAsync(InsDocAttachmentRequestResponse request)
        {
            var messageResponse = new MessageResponse<InsDocAttachmentRequestResponse>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.SaveAttachment),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            var insDocAttachmentValidator = new InsDocAttachmentPostValidator(HttpMethods.Post);
            var insDocAttachment = new InsDocAttachment
            {
                InspectionDocumentId = request.InspectionDocumentId,
                Name = request.Name,
                AttachmentFile = request.AttachmentFile
                //AttachmentDate = request.AttachmentDate
            };

            var validatorResult = insDocAttachmentValidator.Validate(insDocAttachment);
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

            if (request.InspectionDocumentId > 0)
            {
                var inspectionDocumentFinished = await _inspectionDocumentService.FindByInspectionDocumentAsync(request.InspectionDocumentId);

                var attachmentFinal = inspectionDocumentFinished != null
                                      && inspectionDocumentFinished.EndDate != null
                                      && request.Name.Contains("DF_" + inspectionDocumentFinished.SequentialCode);

                if (!attachmentFinal
                    && (inspectionDocumentFinished == null || inspectionDocumentFinished.EndDate != null))
                {
                    inconsistencies.Add(new Inconsistencies
                    {
                        Field = "inspectionDocumentFinished",
                        Description = Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileSavingDeletingInsDocAttachment)
                    });
                }
            }

            messageResponse.Inconsistencies = inconsistencies.ToArray();

            if (inconsistencies.Count > 0)
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileSaving);
                messageResponse.IsSuccess = false;
            }
            else
            {
                try
                {
                    await _insDocAttachmentService.InsertInsDocAttachmentAsync(request);
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
                        Enumerations.GetDescription(SuccessAndErrorMessages.SuccessfullySaved)
                        : Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileSaving);
            }

            return messageResponse;
        }

        public async Task<MessageResponse<InsDocAttachmentRequestResponse>> DeleteInsDocAttachmentAsync(decimal inspectionDocumentId, decimal insDocAttachmentId)
        {
            var messageResponse = new MessageResponse<InsDocAttachmentRequestResponse>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.DeleteAttachment),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            var insDocAttachmentValidator = new InsDocAttachmentDeleteValidator(HttpMethods.Delete);
            var insDocAttachment = new InsDocAttachment
            {
                InspectionDocumentId = inspectionDocumentId,
                InsDocAttachmentId = insDocAttachmentId
            };

            var validatorResult = insDocAttachmentValidator.Validate(insDocAttachment);
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

            var inspectionDocument = await _inspectionDocumentService.FindByInspectionDocumentAsync(inspectionDocumentId);
            if (inspectionDocument == null || inspectionDocument.EndDate != null)
            {
                inconsistencies.Add(new Inconsistencies
                {
                    Field = "InspectionDocumentId and InspDocAttachmentId",
                    Description = Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileSavingDeletingInsDocAttachment)
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
                    await _insDocAttachmentService.DeleteInsDocAttachmentAsync(inspectionDocumentId, insDocAttachmentId);
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

            return messageResponse;
        }
    }
}