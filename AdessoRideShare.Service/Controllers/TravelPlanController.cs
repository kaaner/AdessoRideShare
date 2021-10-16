using AdessoRideShare.BL.Abstract;
using AdessoRideShare.Shared.CriteriaObjects;
using AdessoRideShare.Shared.Dtos;
using AdessoRideShare.Shared.Utils.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdessoRideShare.Service.Controllers
{
  [ApiController]
  //[Route("api/v1/[controller]")]
  [Route("api/v1/travel")]
  public class TravelPlanController : ControllerBase
  {
    private ITravelPlanService _travelPlanService;
    private readonly ILogger<TravelPlanController> _logger;

    public TravelPlanController(ITravelPlanService travelPlan, ILogger<TravelPlanController> logger)
    {
      _travelPlanService = travelPlan;
      _logger = logger;

    }

    [HttpGet]
    [Route("getByDate")]
    public async Task<IDataResult<List<TravelPlanDto>>> GetByDate([FromQuery] DateCo co)
    {
      _logger.LogInformation("GetByDate triggered.");

      return await _travelPlanService.GetByDate(co);
    }

    [HttpPost]
    [Route("add")]
    public async Task<IDataResult<TravelPlanDto>> Add(TravelPlanDto data)
    {
      _logger.LogInformation("Add triggered.");

      return await _travelPlanService.Add(data);
    }

    [HttpPut]
    [Route("publish")]
    public async Task<IDataResult<TravelPlanDto>> Publish(PublishCo co)
    {
      _logger.LogInformation("Publish triggered.");

      return await _travelPlanService.Publish(co);
    }
  }
}
