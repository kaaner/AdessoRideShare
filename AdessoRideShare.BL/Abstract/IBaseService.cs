using AdessoRideShare.Shared.Dtos;
using AdessoRideShare.Shared.Utils.Result;
using System.Threading.Tasks;

namespace AdessoRideShare.BL.Abstract
{
  public interface IBaseService<T>
  {
    Task<IDataResult<T>> Add(T model);
    Task<IDataResult<T>> GetAll();
    Task<IDataResult<T>> GetAllByNonDeleted();
    Task<IDataResult<T>> GetAllByNonDeletedAndActive();
    Task<IDataResult<T>> Update(T model, string modifiedByName);
    Task<IDataResult<T>> Delete(int id, string modifiedByName);
    Task<IResult> HardDelete(int id);
    Task<IDataResult<T>> Get(int id);
  }
}
