using AdessoRideShare.BL.Abstract;
using AdessoRideShare.DataAccess.Abstract;
using AdessoRideShare.Entity;
using AdessoRideShare.Shared.CriteriaObjects;
using AdessoRideShare.Shared.Dtos;
using AdessoRideShare.Shared.Utils;
using AdessoRideShare.Shared.Utils.ComplexTypes;
using AdessoRideShare.Shared.Utils.Result;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdessoRideShare.BL.Concrete
{
  public class ParticipantService : IParticipantService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ParticipantService(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }
    public async Task<IDataResult<ParticipantDto>> Add(ParticipantDto participantDto)
    {
      var travelPlan = _unitOfWork.TravelPlan.GetAsync(t => t.Id == participantDto.TravelPlanId);
      if (travelPlan.Result != null) //TravelPlan exists
      {

        var participants = _unitOfWork.Participant.GetAllAsync(p => p.TravelPlanId == participantDto.TravelPlanId);

        if (participants != null && participants.Result.Count < travelPlan.Result.SeatCount)//Participant count control
        {
          var participant = _mapper.Map<Participant>(participantDto);
          participant.TravelPlan = travelPlan.Result;
          var addedParticipant = _unitOfWork.Participant.AddAsync(participant);
          await _unitOfWork.SaveAsync();

          participantDto.Id = addedParticipant.Result.Id;
          return new DataResult<ParticipantDto>(ResultStatus.Success, participantDto);
        }
        else
        {
          return new DataResult<ParticipantDto>(ResultStatus.Error, "Insufficient seat", null);
        }
      }
      else
      {
        return new DataResult<ParticipantDto>(ResultStatus.Error, "Travel Plan not found", null);
      }
    }

    public Task<IDataResult<ParticipantDto>> Delete(int participantId, string modifiedByName)
    {
      throw new NotImplementedException();
    }

    public Task<IDataResult<ParticipantDto>> Get(int participantId)
    {
      throw new NotImplementedException();
    }

    public Task<IDataResult<ParticipantDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<IDataResult<ParticipantDto>> GetAllByNonDeleted()
    {
      throw new NotImplementedException();
    }

    public Task<IDataResult<ParticipantDto>> GetAllByNonDeletedAndActive()
    {
      throw new NotImplementedException();
    }

    public Task<IResult> HardDelete(int participantId)
    {
      throw new NotImplementedException();
    }

    public Task<IDataResult<ParticipantDto>> Update(ParticipantDto participantDto, string modifiedByName)
    {
      throw new NotImplementedException();
    }
  }
}
