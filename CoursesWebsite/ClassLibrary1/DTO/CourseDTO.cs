using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Infrastructure.DTO
{
    public class CourseDTO
    {
        string Name { get; set; }
        string Description { get; set; }
        public List<TopicDTO> Topics { get; set; }
    }
}
