using APICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
