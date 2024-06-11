using Courses.Core.Models.Courses;
using Courses.Core.Models.Users;

namespace Courses.Core.Models.Accesses
{
    public sealed class UserCoursesAccess
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Course Course { get; set; }
    }
}
