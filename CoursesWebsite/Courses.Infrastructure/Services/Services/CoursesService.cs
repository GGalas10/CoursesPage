using AutoMapper;
using Courses.Core.Models.Courses;
using Courses.Core.Repositories;
using Courses.Core.Value_Object;
using Courses.Infrastructure.Comands.Course;
using Courses.Infrastructure.DTO;
using Courses.Infrastructure.DTO.CoursesDTO;
using Courses.Infrastructure.Services.Interfaces;

namespace Courses.Infrastructure.Services.Services
{
    public class CoursesService : ICourseService
    {
        private readonly ICoursesRepository _coursesRepostiotory;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CoursesService(ICoursesRepository coursesRepostiotory, IUserRepository userRepository, IMapper mapper)
        {
            _coursesRepostiotory = coursesRepostiotory;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CourseDTO> GetByIdAsync(Guid courseId)
        => _mapper.Map<CourseDTO>(await _coursesRepostiotory.GetAsync(courseId));

        public async Task<IEnumerable<ViewCoursesDTO>> GetAllAsync()
        => _mapper.Map<IEnumerable<ViewCoursesDTO>>(await _coursesRepostiotory.GetAllAsync());
        public async Task<IEnumerable<CartCourseDTO>> GetCoursesForCart(IEnumerable<Guid> guids)
        {
            List<CartCourseDTO> list = new List<CartCourseDTO>();
            foreach (var courseId in guids)
            {
                list.Add(_mapper.Map<CartCourseDTO>(await _coursesRepostiotory.GetAsync(courseId)));
            }
            return list;
        }
        public async Task<IEnumerable<ViewCoursesDTO>> GetByCourseIdAsync(IEnumerable<Guid> guids)
        {
            List<ViewCoursesDTO> list = new List<ViewCoursesDTO>();
            foreach (var courseId in guids)
            {
                list.Add(_mapper.Map<ViewCoursesDTO>(await _coursesRepostiotory.GetAsync(courseId)));
            }
            return list;
        }
        public async Task<IEnumerable<ViewCoursesDTO>> GetByCategoryAsync(Guid categoryId)
            => _mapper.Map<IEnumerable<ViewCoursesDTO>>(await Task.FromResult(_coursesRepostiotory.GetAllAsync().Result));
        public async Task<Guid> CreateAsync(Create command,Guid UserId)
        {
            var user = await _userRepository.GetByIdAsync(UserId);
            DigitalItem picture = await DigitalItem.CreateFromIFromFile(command.CoursePicture);
            var course = new Course(command.Title, command.Description, command.AuthorName, picture, Math.Round(command.Price, 2),user);
            return await _coursesRepostiotory.CreateAsync(course);
        }
        public async Task AddTopicAsync(Guid courseId, string name, string description)
        {
            var topic = new Topic(name, description);
            await _coursesRepostiotory.AddTopicAsync(courseId, topic);
            await Task.CompletedTask;
        }
        public async Task<int> AddLessonAsync(AddLessonCommand command)
        {
            var topic = await _coursesRepostiotory.GetTopicByIdAsync(command.topicId);
            var lesson = new Lesson(command.lessonName,command.lessonDescription,null,topic.Lessons.Count()+1);
            await _coursesRepostiotory.AddLessonAsync(command.topicId, lesson);
            return lesson.LessonNumber;
        }
        public async Task<CourseDetails> GetCourseDetailsByIdAsync(Guid courseId)
        {
            var course = await _coursesRepostiotory.GetAsync(courseId);
            var detailsDTO = new CourseDetails(course);
            return detailsDTO;
        }

        public async Task<LessonEditDTO> GetLessonByIdAsync(Guid lessonId)
        {
            var lesson = await _coursesRepostiotory.GetLessonByIdAsync(lessonId);
            return new LessonEditDTO(lesson);
        }
    }
}
