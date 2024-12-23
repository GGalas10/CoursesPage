using Courses.Core.Models.Courses;

namespace Courses.Core.Repositories
{
    public interface ICoursesRepository
    {
        Task<Course> GetAsync(Guid id);
        Task<List<Course>> GetAllAsync();
        Task<List<Course>> GetAllByCategoryIdAsync(Guid categoryId);
        Task<Guid> CreateAsync(Course course);
        Task UpdateAsync(Guid id,Course course);
        Task DeleteAsync(Guid id);
        Task AddTopicAsync(Guid id,Topic topic);
        Task AddTopicsAsync(Guid id,List<Topic> topic);
        Task AddLessonAsync(Guid IdTopic, Lesson lesson);
        Task AddLessonsAsync(Guid IdTopic, List<Lesson> lessons);
        Task<Topic> GetTopicByIdAsync(Guid topicId);
        Task<Lesson> GetLessonByIdAsync(Guid lessonId);
    }
}
