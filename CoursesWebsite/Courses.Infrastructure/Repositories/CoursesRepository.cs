using Courses.Core.Models.Commons;
using Courses.Core.Models.Courses;
using Courses.Core.Repositories;
using Courses.DataAccess.Context;
using Courses.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Courses.Infrastructure.Services
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly CoursesDbContext _context;
        public CoursesRepository(CoursesDbContext context)
        {
            _context = context;
        }
        public async Task<Course> GetAsync(Guid id)
        => await _context.Courses.Include(x=>x.Topics).ThenInclude(x=>x.Lessons).FirstOrDefaultAsync(c => c.Id == id && c.State == State.Active);
        public async Task<List<Course>> GetAllAsync()
            => await _context.Courses.Where(c => c.State == State.Active).ToListAsync();
        public async Task<List<Course>> GetAllByCategoryIdAsync(Guid categoryId)
        {
            var allGuidInCategory = await _context.coursesCategories.Where(c=>c.CategoryId == categoryId).ToListAsync();
            var allCourses = new List<Course>();
            foreach(var oneGuid in allGuidInCategory)
            {
                allCourses.Add(await GetAsync(oneGuid.CourseId));
            }
            return allCourses;
        }
        public async Task<Guid> CreateAsync(Course course)
        {
            var cours = await _context.Courses.FirstOrDefaultAsync(c=>c.Name == course.Name);
            if (cours != null)
                throw new Exception($"A cours with this name already exists");
            _context.Courses.Add(course);
            if (_context.SaveChangesAsync().Result > 0)
                return course.Id;
            else
                throw new Exception("Db can't save date");
        }
        public async Task UpdateAsync(Guid id, Course course)
        {
            var upCourse = await this.GetOrFailById(id);
            upCourse.SetName(course.Name);
            upCourse.SetDescription(course.Description);
            upCourse.SetAuthor(course.Author);
            foreach(var topic in course.Topics)
            {
                if(!upCourse.Topics.Contains(topic))
                    upCourse.AddTopic(topic);
            }
            if (_context.SaveChangesAsync().Result > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Db can't save date");
        }
        public async Task DeleteAsync(Guid id)
        {
            var deletedCours = await this.GetOrFailById(id);
            deletedCours.SetState(State.Deleted);
            if (_context.SaveChangesAsync().Result > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Db can't save date");
        }     
        public async Task AddTopicAsync(Guid id, Topic topic) 
        {
            if (topic == null)
                throw new Exception("Topic can't be empty");
            var Course = await this.GetOrFailById(id);
            Course.AddTopic(topic);
            _context.topics.Add(topic);
            if (await _context.SaveChangesAsync() > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Db can't save date");
        }
        public async Task AddTopicsAsync(Guid id,List<Topic> topic) 
        {
            if (topic.Count<0)
                throw new Exception("List of topic can't be empty");
            var Course = await this.GetOrFailById(id);
            Course.AddTopics(topic);
			_context.topics.AddRange(topic);
			if (_context.SaveChangesAsync().Result > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Db can't save date");
        }
        public async Task AddLessonAsync(Guid idTopic, Lesson lesson)
        {
            if (lesson == null)
                throw new Exception("Lesson can't be empty");
            var Topic = await _context.topics.Include(x=>x.Lessons).FirstOrDefaultAsync(t => t.Id == idTopic);
            if (Topic == null)
                throw new Exception("Topic doesn't exists");
            Topic.AddLesson(lesson);
            _context.Add(lesson);
            _context.Update(Topic);
			if (await _context.SaveChangesAsync() > 0)
                await Task.CompletedTask;
            else
                throw new Exception("Db can't save date");
        }
        public async Task AddLessonsAsync(Guid idTopic, List<Lesson> lessons)
        {
            if (lessons.Count < 0)
                throw new Exception("List of lessons can't be empty");
            var Topic = await _context.topics.FirstOrDefaultAsync(t => t.Id == idTopic);
            if (Topic == null)
                throw new Exception("Topic doesn't exists");
            foreach(var lesson in lessons)
            {
                Topic.AddLesson(lesson);
            }
			_context.lessons.AddRange(lessons);
			if (_context.SaveChangesAsync().Result>0)
                await Task.CompletedTask;
            else
                throw new Exception("Db can't save date");
        }
        public async Task<Topic> GetTopicByIdAsync(Guid topicId)
        {
            if (topicId == Guid.Empty)
                throw new Exception("Topic Id cannot be empty");
            var topic = await _context.topics.AsNoTracking().AsSplitQuery().Include(x=>x.Lessons).FirstOrDefaultAsync(x=>x.Id == topicId);
            if (topic == null)
                throw new Exception($"Cannot find Topic with Id:{topicId}");
            return topic;
        }
    }
}
