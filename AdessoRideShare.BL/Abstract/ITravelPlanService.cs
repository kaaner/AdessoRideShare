using AdessoRideShare.Shared.CriteriaObjects;
using AdessoRideShare.Shared.Dtos;
using AdessoRideShare.Shared.Utils.Result;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdessoRideShare.BL.Abstract
{
  public interface ITravelPlanService : IBaseService<TravelPlanDto>
  {
    Task<IDataResult<List<TravelPlanDto>>> GetByDate(DateCo co);
    Task<IDataResult<TravelPlanDto>> Publish(PublishCo co);
  }
}
