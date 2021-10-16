using AdessoRideShare.DataAccess.Abstract;
using AdessoRideShare.DataAccess.Concrete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoRideShare.DataAccess.Concrete
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly Context _context;

    private TravelPlanRepository _travelPlanRepository;
    private ParticipantRepository _participantRepository;

    public UnitOfWork(Context context)
    {
      _context = context;
    }
    public ITravelPlanRepository TravelPlan => _travelPlanRepository ?? new TravelPlanRepository(_context);
    public IParticipantRepository Participant => _participantRepository ?? new ParticipantRepository(_context);

    public async ValueTask DisposeAsync()
    {
      await _context.DisposeAsync();
    }

    public async Task<int> SaveAsync()
    {
      return await _context.SaveChangesAsync();
    }
  }
}
