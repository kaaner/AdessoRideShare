using AdessoRideShare.DataAccess.Abstract;
using AdessoRideShare.Entity;
using Microsoft.EntityFrameworkCore;

namespace AdessoRideShare.DataAccess.Concrete.Repositories
{
  public class ParticipantRepository : EfEntityRepositoryBase<Participant>, IParticipantRepository
  {
    public ParticipantRepository(DbContext context) : base(context)
    {
    }
  }
}
