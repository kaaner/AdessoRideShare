using AdessoRideShare.Shared.Data;
using System;
using System.Collections.Generic;

namespace AdessoRideShare.Entity
{
  public class TravelPlan : Base, IEntity
  {
    public TravelPlan()
    {
      Participants = new HashSet<Participant>();
    }
    public string From { get; set; } = "A";
    public string To { get; set; }
    public DateTime Date { get; set; }
    public string FormattedDate
    {
      get
      {
        return string.Format("{0:dd/MM/yyyy hh:mm}", Date);
      }
    }
    public string Description { get; set; }
    public int SeatCount { get; set; }
    public bool IsPublished { get; set; }

    public ICollection<Participant> Participants { get; set; }

  }
}
