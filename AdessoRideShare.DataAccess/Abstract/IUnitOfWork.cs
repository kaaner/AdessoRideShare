using System;
using System.Threading.Tasks;

namespace AdessoRideShare.DataAccess.Abstract
{
  public interface IUnitOfWork : IAsyncDisposable
  {

    ITravelPlanRepository TravelPlan { get; }
    IParticipantRepository Participant { get; }
    
    Task<int> SaveAsync();
  }
}
