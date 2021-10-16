using AdessoRideShare.DataAccess;
using AdessoRideShare.DataAccess.Abstract;
using AdessoRideShare.DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace AdessoRideShare.BL.Extensions
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
    {
      serviceCollection.AddDbContext<Context>();
      serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
      return serviceCollection;
    }
  }
}
