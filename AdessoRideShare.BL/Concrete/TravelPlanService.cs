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
  public class TravelPlanService : ITravelPlanService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public TravelPlanService(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }
    public async Task<IDataResult<TravelPlanDto>> Add(TravelPlanDto travelPlanDto)
    {
      var travelPlan = _mapper.Map<TravelPlan>(travelPlanDto);
      var addedPatient = _unitOfWork.TravelPlan.AddAsync(travelPlan);
      await _unitOfWork.SaveAsync();

      travelPlanDto.Id = addedPatient.Result.Id;
      return new DataResult<TravelPlanDto>(ResultStatus.Success, travelPlanDto);
    }

    public Task<IDataResult<TravelPlanDto>> Delete(int travelPlanId, string modifiedByName)
    {
      throw new NotImplementedException();
    }

    public Task<IDataResult<TravelPlanDto>> Get(int travelPlanId)
    {
      throw new NotImplementedException();
    }

    public Task<IDataResult<TravelPlanDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<IDataResult<TravelPlanDto>> GetAllByNonDeleted()
    {
      throw new NotImplementedException();
    }

    public Task<IDataResult<TravelPlanDto>> GetAllByNonDeletedAndActive()
    {
      throw new NotImplementedException();
    }

    public async Task<IDataResult<List<TravelPlanDto>>> GetByDate(DateCo co)
    {
      var travelPlans = _unitOfWork.TravelPlan.GetAllAsync(t => t.Date <= co.From && t.Date >= co.To);
      if (travelPlans.Result != null && travelPlans.Result.Count > 0)
      {

        var travelPlanDtos = _mapper.Map<List<TravelPlanDto>>(travelPlans.Result);
        return new DataResult<List<TravelPlanDto>>(ResultStatus.Success, travelPlanDtos);
      }
      else {
        return new DataResult<List<TravelPlanDto>>(ResultStatus.Error, "Data not found", null);
      }
    }

    public Task<IResult> HardDelete(int travelPlanId)
    {
      throw new NotImplementedException();
    }

    public async Task<IDataResult<TravelPlanDto>> Publish(PublishCo co)
    {
      var travelPlan = _unitOfWork.TravelPlan.GetAsync(t => t.Id == co.TravelPlanId);
      if (travelPlan.Result != null)
      {
        travelPlan.Result.IsPublished = co.Status;
        await _unitOfWork.TravelPlan.UpdateAsync(travelPlan.Result);
        await _unitOfWork.SaveAsync();
      }
      else {
        return new DataResult<TravelPlanDto>(ResultStatus.Error, "Data not found", null);
      }

      var travelPlanDto = _mapper.Map<TravelPlanDto>(travelPlan.Result);
      return new DataResult<TravelPlanDto>(ResultStatus.Success, travelPlanDto);
    }

    public Task<IDataResult<TravelPlanDto>> Update(TravelPlanDto travelPlanDto, string modifiedByName)
    {
      throw new NotImplementedException();
    }
  }
}
