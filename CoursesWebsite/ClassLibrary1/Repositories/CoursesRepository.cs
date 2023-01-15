using APICore.Models;

namespace Infrastructure.Services
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly CoursesDbContext _context;
        public CoursesRepository(CoursesDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Course course)
        {
            var cours = _context.Courses.FirstOrDefault(c=>c.Name == course.Name);
            if (cours != null)
                throw new Exception($"A cours with this name already exists");
            _context.Courses.Add(course);
            _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var deletedCours= await Task.FromResult(_context.Courses.FirstOrDefault(c=>c.Id == id));
            deletedCours.SetState(State.Deleted);
            _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<List<Course>> GetAllAsync()
            => await Task.FromResult(_context.Courses.Where(c=>c.state == State.Active).ToList());

        public async Task<Course> GetAsync(Guid id)
        => await Task.FromResult(_context.Courses.FirstOrDefault(c=>c.Id==id && c.state == State.Active));

        public async Task UpdateAsync(Guid id,Course course)
        {
            var upCourse = await Task.FromResult(_context.Courses.FirstOrDefault(course=>course.Id == id));
            upCourse.SetName(course.Name);
            upCourse.SetDescription(course.Description);
            upCourse.SetAuthor(course.Author);
            _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
        public async Task AddTopicAsync(Guid id, Topic topic) 
        {
            if (topic == null)
                throw new Exception("Topic can't be empty");
            var Course = await Task.FromResult(_context.Courses.FirstOrDefault(c => c.Id == id));
            Course.AddTopic(topic);
            _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
        public async Task AddTopicsAsync(Guid id,List<Topic> topic) 
        {
            if (topic.Count<0)
                throw new Exception("List of topic can't be empty");
            var Course = await Task.FromResult(_context.Courses.FirstOrDefault(c => c.Id == id));
            Course.AddTopic(topic);
            _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
        public async Task AddLessonAsync(Guid idCourses, Guid idTopic, Lesson lesson)
        {
            if (lesson == null)
                throw new Exception("Lesson can't be empty");
            var Topic = await Task.FromResult(_context.Courses.FirstOrDefault(c => c.Id == idCourses).Topics.FirstOrDefault(t => t.Id == idTopic));
            if (Topic == null)
                throw new Exception("Topic doesn't exists");
            Topic.AddLesson(lesson);
            _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
        public async Task AddLessonsAsync(Guid idCourses, Guid idTopic, List<Lesson> lessons)
        {
            if (lessons.Count < 0)
                throw new Exception("List of lessons can't be empty");
            var Topic = await Task.FromResult(_context.Courses.FirstOrDefault(c => c.Id == idCourses).Topics.FirstOrDefault(t => t.Id == idTopic));
            if (Topic == null)
                throw new Exception("Topic doesn't exists");
            foreach(var lesson in lessons)
            {
                Topic.AddLesson(lesson);
            }
            _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
