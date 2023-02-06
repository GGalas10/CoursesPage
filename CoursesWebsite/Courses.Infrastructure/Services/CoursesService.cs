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
        => await _mapper.Map<_coursesRepostiotory.GetAsync(courseId)>(CourseDTO);
        public Task<IEnumerable<ViewCoursesDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<ViewCoursesDTO>> GetByCourseIdAsync(IEnumerable<Guid> guids)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<ViewCoursesDTO>> GetByCategoryAsync(Guid categoryId)
        {
            throw new NotImplementedException();
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
