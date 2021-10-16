using AdessoRideShare.Entity;
using AdessoRideShare.Shared.Dtos;
using AutoMapper;

namespace AdessoRideShare.BL.AutoMapper
{
  public class MapperProfile : Profile
  {
    public MapperProfile()
    {
      CreateMap<TravelPlan, TravelPlanDto>();
      CreateMap<TravelPlanDto, TravelPlan>().ReverseMap();
      CreateMap<Participant, ParticipantDto>();
      CreateMap<ParticipantDto, Participant>().ReverseMap();
    }
  }
}
