using Courses.Core.Models;
using AutoMapper;
using Courses.Infrastructure.DTO;

namespace Courses.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>()
                .ForMember(p=>p.Name, m=>m.MapFrom(p=>p.UserName))
                .ForMember(p=>p.AvailableCourses,m=>m.MapFrom(p=>p.PurchasedCourses));
                cfg.CreateMap<Course, CourseDTO>()
                .ForMember(c => c.Topics, m => m.MapFrom(p => p.Topics))
                .ForMember(c=>c.Name,m=>m.MapFrom(p=>p.Name))
                .ForMember(c=>c.Description,m=>m.MapFrom(p=>p.Description));
            }).CreateMapper(); 
    }
}
