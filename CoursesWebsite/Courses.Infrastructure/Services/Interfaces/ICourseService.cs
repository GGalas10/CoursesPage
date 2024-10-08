﻿using Courses.Core.Value_Object;
using Courses.Infrastructure.Comands.Course;
using Courses.Infrastructure.DTO;

namespace Courses.Infrastructure.Services.Interfaces
{
    public interface ICourseService
    {
        Task<CourseDTO> GetByIdAsync(Guid courseId);
        Task<IEnumerable<ViewCoursesDTO>> GetAllAsync();
        Task<IEnumerable<ViewCoursesDTO>> GetByCourseIdAsync(IEnumerable<Guid> guids);
        Task<IEnumerable<CartCourseDTO>> GetCoursesForCart(IEnumerable<Guid> guids);
        Task<IEnumerable<ViewCoursesDTO>> GetByCategoryAsync(Guid categoryId);
        Task<Guid> CreateAsync(Create command,Guid userId);
        Task AddTopicAsync(Guid courseId, string name, string description);
        Task<int> AddLessonAsync(AddLessonCommand command);
        Task<CourseDetails> GetCourseDetailsByIdAsync(Guid courseId);
    }
}
