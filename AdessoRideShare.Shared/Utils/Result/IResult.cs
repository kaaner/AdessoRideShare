using AdessoRideShare.Shared.Utils.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdessoRideShare.Shared.Utils.Result
{
  public interface IResult
  {
    public ResultStatus Result { get; }
    public string Message { get; }
    public Exception Exception { get; }
  }
}
