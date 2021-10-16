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
  [Route("api/v1/participate")]
  public class ParticipantController : ControllerBase
  {
    private IParticipantService _participantService;
    private readonly ILogger<ParticipantController> _logger;

    public ParticipantController(IParticipantService participant, ILogger<ParticipantController> logger)
    {
      _participantService = participant;
      _logger = logger;

    }

    [HttpPost]
    [Route("add")]
    public async Task<IDataResult<ParticipantDto>> Add(ParticipantDto model)
    {
      _logger.LogInformation("Add triggered.");

      return await _participantService.Add(model);
    }
  }
}
