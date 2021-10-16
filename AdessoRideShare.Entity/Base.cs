using System;

namespace AdessoRideShare.Entity
{
  public class Base
  {
    public virtual int Id { get; set; }
    public virtual DateTime CreatedOn { get; set; } = DateTime.Now;
    public virtual string CreatedByName { get; set; } = "Kaan Er";
    public virtual bool? IsDeleted { get; set; } = false;
  }
}
