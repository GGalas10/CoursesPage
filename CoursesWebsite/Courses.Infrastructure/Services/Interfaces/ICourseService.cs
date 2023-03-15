﻿using Courses.Core.Value_Object;
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
        Task CreateAsync(string name, string description, string author, DigitalItem picture,double price);
        Task AddTopicAsync(Guid courseId, string name, string description);
        Task AddLessonAsync(Guid courseId, Guid topicId, string name, string description, byte[] video);
    }
}
