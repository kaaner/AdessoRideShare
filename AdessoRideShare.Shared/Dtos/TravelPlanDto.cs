using System;

namespace AdessoRideShare.Shared.Dtos
{
  public class TravelPlanDto:BaseDto
  {
    public string From { get; set; } = "A";
    public string To { get; set; } = "B";
    public DateTime Date { get; set; }
    public string FormattedDate
    {
      get
      {
        return string.Format("{0:dd/MM/yyyy hh:mm}", Date);
      }
    }
    public string Description { get; set; } = "test travel";
    public int SeatCount { get; set; } = 20;
    public bool IsPublished { get; set; } = false;
  }
}
