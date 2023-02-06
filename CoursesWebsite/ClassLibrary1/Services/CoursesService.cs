using AutoMapper;
using Courses.Core.Repositories;
using Courses.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Infrastructure.Services
{
    public class CoursesService : ICourseService
    {
        private readonly ICoursesRepository _coursesRepostiotory;
        private readonly IMapper _mapper;
        public CoursesService(ICoursesRepository coursesRepostiotory,IMapper mapper)
        {
            _coursesRepostiotory = coursesRepostiotory;
            _mapper = mapper;
        }

        public async Task<CourseDTO> GetByIdAsync(Guid courseId)
        =>_mapper.Map<CourseDTO>(await _coursesRepostiotory.GetAsync(courseId));

        public async Task<IEnumerable<ViewCoursesDTO>> GetAllAsync()
        => _mapper.Map<IEnumerable<ViewCoursesDTO>>(await _coursesRepostiotory.GetAllAsync());
        public async Task<IEnumerable<ViewCoursesDTO>> GetByCourseIdAsync(IEnumerable<Guid> guids)
        {
            List<ViewCoursesDTO> list = new List<ViewCoursesDTO>();
            foreach(var courseId in guids)
            {
                list.Add(_mapper.Map<ViewCoursesDTO>(await _coursesRepostiotory.GetAsync(courseId)));  
            }
            return list;
        }
        public async Task<IEnumerable<ViewCoursesDTO>> GetByCategoryAsync(Guid categoryId)
        {
            _mapper.Map<IEnumerable<ViewCoursesDTO>>(await _coursesRepostiotory.GetAllAsync().Result.Where(c => c.Categories.FirstOrDefault().id ==);
        }
        public Task CreateAsync(string name, string description, string author)
        {
            throw new NotImplementedException();
        }
        public Task AddTopicAsync(Guid courseId, string name, string description)
        {
            throw new NotImplementedException();
        }
        public Task AddLessonAsync(Guid courseId, Guid topicId, string name, string description, byte[] video)
        {
            throw new NotImplementedException();
        }  
    }
}
