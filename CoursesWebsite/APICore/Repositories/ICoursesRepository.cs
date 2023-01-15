using APICore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ICoursesRepository
    {
        Task<Course> GetAsync(Guid id);
        Task<List<Course>> GetAllAsync();
        Task CreateAsync(Course course);
        Task UpdateAsync(Guid id,Course course);
        Task DeleteAsync(Guid id);
        Task AddTopicAsync(Guid id,Topic topic);
        Task AddTopicsAsync(Guid id,List<Topic> topic);
        Task AddLessonAsync(Guid idCourse,Guid IdTopic, Lesson lesson);
        Task AddLessonsAsync(Guid idCourse, Guid IdTopic, List<Lesson> lessons);
    }
}
