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
    public class SequentialAppService : ISequentialAppService
    {
        private readonly ISequentialService _sequentialService;
        private readonly IUnitOfWork _unitOfWork;

        public SequentialAppService(ISequentialService sequentialService, IUnitOfWork unitOfWork)
        {
            _sequentialService = sequentialService;
            _unitOfWork = unitOfWork;
        }

        public async Task<MessageResponse<IEnumerable<SequentialRequestResponse>>> ListAsync()
        {
            var messageResponse = new MessageResponse<IEnumerable<SequentialRequestResponse>>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfSequential),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            try
            {
                var sequential = await _sequentialService.ListAsync();
                messageResponse.Data = sequential;
                messageResponse.Message = messageResponse.Data.Any() ? Enumerations.GetDescription(SuccessAndErrorMessages.SuccessfullyListed) : Enumerations.GetDescription(SuccessAndErrorMessages.NoDateFound);
                messageResponse.Count = messageResponse.Data.Any() ? messageResponse.Data.Count() : 0;
                messageResponse.IsSuccess = true;
            }
            catch (Exception e)
            {
                messageResponse.IsSuccess = false;
                messageResponse.Message = e.Message.ToString();
            }

            return messageResponse;
        }

        public async Task<IEnumerable<SequentialRequestResponse>> ListBySequentialAsync(decimal inspectionAgentId)
        {
            return await _sequentialService.ListBySequentialAsync(inspectionAgentId);
        }

        public async Task<MessageResponse<SequentialRequestResponse>> FindBySequentialAsync(decimal inspectionAgentId)
        {
            var messageResponse = new MessageResponse<SequentialRequestResponse>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.ListOfSequential),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            if (inspectionAgentId < 0)
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.FieldMustGreaterThanZero);
                messageResponse.IsSuccess = false;
            }
            else
            {
                try
                {
                    var sequential = await _sequentialService.FindBySequentialAsync(inspectionAgentId);
                    messageResponse.Data = sequential;
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

        public async Task<MessageResponse<SequentialRequestResponse>> InsertSequentialAsync(decimal inspectionAgentId, decimal sequentialCodeStart, decimal sequentialCodeEnd)
        {
            var messageResponse = new MessageResponse<SequentialRequestResponse>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.InsertSequential),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            sequentialCodeEnd = sequentialCodeEnd > 0 ? sequentialCodeEnd : sequentialCodeStart;

            if (sequentialCodeStart > sequentialCodeEnd)
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.StartingNumberGreaterThanEndingNumber);
                messageResponse.IsSuccess = false;
                return messageResponse;
            }

            for (decimal i = sequentialCodeStart; i <= sequentialCodeEnd; i++)
            {
                var sequentialValidator = new SequentialPostValidator(HttpMethods.Post);
                var sequential = new Sequential
                {
                    InspectionAgentId = inspectionAgentId,
                    SequentialCode = i
                };

                var validatorResult = sequentialValidator.Validate(sequential);
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

                var sequentialDf = await _sequentialService.FindBySequentialInspectionAgentAsync(inspectionAgentId, i);
                if (sequentialDf != null)
                {
                    inconsistencies.Add(new Inconsistencies
                    {
                        Field = "FindBySequentialInspectionAgentAsync",
                        Description = Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileSavingSequentialInspectionAgent) + " SequentialCode: " + i.ToString()
                    });
                }

                messageResponse.Inconsistencies = inconsistencies.ToArray();

                if (inconsistencies.Count > 0)
                {
                    messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileInserting);
                    messageResponse.IsSuccess = false;
                    break;
                }
                else
                {
                    try
                    {
                        await _sequentialService.InsertSequentialAsync(inspectionAgentId, i);
                        messageResponse.IsSuccess = true;
                    }
                    catch (Exception e)
                    {
                        messageResponse.Message = e.Message.ToString();
                        messageResponse.IsSuccess = false;
                    }
                }
            }

            if (messageResponse.IsSuccess)
            {
                var result = await _unitOfWork.CompletedAsync();
                messageResponse.Message = result ?
                        Enumerations.GetDescription(SuccessAndErrorMessages.SuccessfullyIncluded)
                        : Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileInserting);
            }

            return messageResponse;
        }

        public async Task<MessageResponse<SequentialRequestResponse>> DeleteSequentialAsync(decimal inspectionAgentId, decimal sequentialCodeStart, decimal sequentialCodeEnd)
        {
            var messageResponse = new MessageResponse<SequentialRequestResponse>()
            {
                RequestSource = Enumerations.GetDescription(RequestSource.DeleteSequential),
                ResponseDate = DateTime.UtcNow,
                Count = 0,
                StatusCode = HttpStatusCode.OK
            };

            sequentialCodeEnd = sequentialCodeEnd > 0 ? sequentialCodeEnd : sequentialCodeStart;

            if (sequentialCodeStart > sequentialCodeEnd)
            {
                messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.StartingNumberGreaterThanEndingNumber);
                messageResponse.IsSuccess = false;
                return messageResponse;
            }

            for (decimal i = sequentialCodeStart; i <= sequentialCodeEnd; i++)
            {
                var sequentialValidator = new SequentialDeleteValidator(HttpMethods.Delete);
                var sequential = new Sequential
                {
                    InspectionAgentId = inspectionAgentId,
                    SequentialCode = i
                };

                var validatorResult = sequentialValidator.Validate(sequential);
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

                var sequentialDf = await _sequentialService.FindBySequentialInspectionAgentAsync(inspectionAgentId, i);
                if (sequentialDf == null)
                {
                    inconsistencies.Add(new Inconsistencies
                    {
                        Field = "FindBySequentialInspectionAgentAsync",
                        Description = Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileDeletingSequentialInspectionAgent) + " SequentialCode: " + i.ToString()
                    });
                }

                messageResponse.Inconsistencies = inconsistencies.ToArray();

                if (inconsistencies.Count > 0)
                {
                    messageResponse.Message = Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileDeleting);
                    messageResponse.IsSuccess = false;
                    break;
                }
                else
                {
                    try
                    {
                        await _sequentialService.DeleteSequentialAsync(inspectionAgentId, i);
                        messageResponse.IsSuccess = true;
                    }
                    catch (Exception e)
                    {
                        messageResponse.Message = e.Message.ToString();
                        messageResponse.IsSuccess = false;
                    }
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