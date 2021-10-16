using System;

namespace AdessoRideShare.Shared.Dtos
{
  public class ParticipantDto:BaseDto
  {
    public int UserId { get; set; }
    public int TravelPlanId { get; set; }

    public virtual TravelPlanDto TravelPlan { get; set; }
  }
}
