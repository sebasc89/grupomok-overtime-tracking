using AutoMapper;
using GrupoMok.OvertimeTracking.Application.Dtos.Core;
using GrupoMok.OvertimeTracking.Core.Entities;

namespace GrupoMok.OvertimeTracking.Application.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Area, AreaDto>().ReverseMap();
            CreateMap<Position, PositionDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();

           // CreateMap<Employee, EmployeeDto>()
           //.ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
           //.ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType))
           //.ForMember(dest => dest.DocumentNumber, opt => opt.MapFrom(src => src.DocumentNumber))
           //.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
           //.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
           //.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           //.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
           //.ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
           //.ForMember(dest => dest.AreaId, opt => opt.MapFrom(src => src.AreaId))
           //.ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.PositionId))
           //.ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Area))
           //.ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position)).ReverseMap();
        }
    }
}
