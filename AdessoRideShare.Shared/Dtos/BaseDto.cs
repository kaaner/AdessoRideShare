using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoRideShare.Shared.Dtos
{
  public class BaseDto
  {
    public virtual int Id { get; set; }
    public virtual DateTime CreatedOn { get; set; } = DateTime.Now;
    public virtual string CreatedByName { get; set; } = "Kaan Er";
    public virtual bool? IsDeleted { get; set; } = false;

  }
}
