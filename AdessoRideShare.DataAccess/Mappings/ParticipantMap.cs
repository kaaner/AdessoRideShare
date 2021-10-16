using AdessoRideShare.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoRideShare.DataAccess.Mappings
{
  public class ParticipantMap : IEntityTypeConfiguration<Participant>
  {
    public void Configure(EntityTypeBuilder<Participant> builder)
    {
      builder.HasKey(p => p.Id);
      builder.Property(p => p.Id).ValueGeneratedOnAdd();
      builder.Property(p => p.UserId).IsRequired();

      builder.HasOne<TravelPlan>(p => p.TravelPlan).WithMany(d => d.Participants).HasForeignKey(d => d.TravelPlanId);
    }
  }
}
