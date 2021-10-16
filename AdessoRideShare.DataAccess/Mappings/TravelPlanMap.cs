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
  public class TravelPlanMap : IEntityTypeConfiguration<TravelPlan>
  {
    public void Configure(EntityTypeBuilder<TravelPlan> builder)
    {
      builder.HasKey(p => p.Id);
      builder.Property(p => p.Id).ValueGeneratedOnAdd();
      builder.Property(p => p.Date).IsRequired();
      builder.Property(p => p.From).HasMaxLength(64).IsRequired();
      builder.Property(p => p.To).HasMaxLength(64).IsRequired();
      builder.Property(p => p.IsPublished).IsRequired();
      builder.Property(p => p.SeatCount).IsRequired();
      builder.Property(p => p.Description).HasMaxLength(512).IsRequired();

      //builder.HasMany<Participant>(d => d.Participants).WithOne(p => p.TravelPlan);
    }
  }
}
