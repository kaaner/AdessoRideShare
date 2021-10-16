using AdessoRideShare.DataAccess.Mappings;
using AdessoRideShare.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoRideShare.DataAccess
{
  public class Context : DbContext
  {

    public DbSet<TravelPlan> TravelPlan { get; set; }

    public DbSet<Participant> Participant { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(
                connectionString: "Server=.;Database=AdessoRideShareDb;Trusted_Connection=True;"
        );
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new TravelPlanMap());
      modelBuilder.ApplyConfiguration(new ParticipantMap());
    }
  }
}
