﻿using APICore.Object_Value;
using AutoMapper;
using Courses.Core.Models;
using Courses.Core.Repositories;
using Courses.Core.Value_Object;
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
            => _mapper.Map<IEnumerable<ViewCoursesDTO>>(await Task.FromResult(_coursesRepostiotory.GetAllAsync().Result.Where(c=>c.Categories.Contains(categoryId))));
        public async Task CreateAsync(string name, string description, string author,DigitalItem picture)
        {
            var course = new Course(name, description, author,picture);
            await _coursesRepostiotory.CreateAsync(course);
            await Task.CompletedTask;
        }
        public async Task AddTopicAsync(Guid courseId, string name, string description)
        {
            var topic = new Topic(name, description);
            await _coursesRepostiotory.AddTopicAsync(courseId, topic);
            await Task.CompletedTask;
        }
        public async Task AddLessonAsync(Guid courseId, Guid topicId, string name, string description, byte[] video)
        {
            var course = await _coursesRepostiotory.GetAsync(courseId);
            var topic = course.Topics.FirstOrDefault(t => t.Id == topicId);
            var lesson = new Lesson(name, description, video,(topic.Lessons.Count()+1));
            await _coursesRepostiotory.AddLessonAsync(topicId, lesson);
            await Task.CompletedTask;
        }  
    }
}