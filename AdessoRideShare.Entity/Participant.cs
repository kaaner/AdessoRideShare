using AdessoRideShare.Shared.Data;
using System;
using System.Collections.Generic;

namespace AdessoRideShare.Entity
{
  public class Participant : Base, IEntity
  {
    public int UserId { get; set; }
    public int TravelPlanId { get; set; }

    public TravelPlan TravelPlan { get; set; }
  }
}
