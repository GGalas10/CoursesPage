using AutoMapper;
using Courses.Core.Models.Categories;
using Courses.Core.Models.Courses;
using Courses.Core.Models.Users;
using Courses.Infrastructure.DTO;
using Courses.Infrastructure.DTO.UserDTOs.Basic;

namespace Courses.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>()
                .ForMember(p => p.Name, m => m.MapFrom(p => p.UserName));
               
                cfg.CreateMap<Course, CourseDTO>()
                .ForMember(c => c.Topics, m => m.MapFrom(p => p.Topics))
                .ForMember(c=>c.Name,m=>m.MapFrom(p=>p.Name))
                .ForMember(c=>c.Description,m=>m.MapFrom(p=>p.Description));
                
                cfg.CreateMap<Course, ViewCoursesDTO>()
                .ForMember(p => p.Name, m => m.MapFrom(p => p.Name));
                
                cfg.CreateMap<Topic, TopicDTO>()
                .ForMember(p => p.lessons, m => m.MapFrom(p=>p.Lessons))
                .ForMember(p=>p.Description,m=>m.MapFrom(p=>p.Description));

                cfg.CreateMap<Lesson,LessonDTO>()
                .ForMember(p=>p.Video, m=>m.MapFrom(p=>p.Video));

                cfg.CreateMap<Course, CartCourseDTO>()
                .ForMember(p => p.Name, m => m.MapFrom(p => p.Name))
                .ForMember(p => p.Price, m => m.MapFrom(p => p.Price));

                cfg.CreateMap<Category, CategoryDTO>()
                .ForMember(p => p.Id, m => m.MapFrom(p => p.Id))
                .ForMember(p => p.Name, m => m.MapFrom(p => p.Name));

                cfg.CreateMap<UserConfiguration, UserConfigDTO>()
                .ForMember(p => p.Theme, m => m.MapFrom(p => p.Theme))
                .ForMember(p => p.Region, m => m.MapFrom(p => p.Region));

            }).CreateMapper(); 
    }
}
