using APICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ICoursesServices
    {
        Task<Course> GetAsync(Guid id);
        Task<List<Course>> GetAllAsync();

        Task CreateAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteAsync(Guid id);
        
    }
}
