using AdessoRideShare.DataAccess.Abstract;
using AdessoRideShare.Entity;
using Microsoft.EntityFrameworkCore;

namespace AdessoRideShare.DataAccess.Concrete.Repositories
{
  public class TravelPlanRepository : EfEntityRepositoryBase<TravelPlan>, ITravelPlanRepository
  {
    public TravelPlanRepository(DbContext context) : base(context)
    {
    }
  }
}
