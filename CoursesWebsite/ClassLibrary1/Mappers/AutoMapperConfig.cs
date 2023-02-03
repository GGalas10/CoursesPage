using Courses.Core.Models;
using AutoMapper;
using Courses.Infrastructure.DTO;

namespace ToDo_List_Courses.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>()
                .ForMember(p=>p.Name, m=>m.MapFrom(p=>p.UserName))
                .ForMember(p=>p.AvailableCourses,m=>m.MapFrom(p=>p.PurchasedCourses));
            }).CreateMapper(); 
    }
}
