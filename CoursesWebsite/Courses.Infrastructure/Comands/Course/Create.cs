using Microsoft.AspNetCore.Http;
namespace Courses.Infrastructure.Comands.Course
{
    public class Create
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile CoursePicture { get; set; }
        public double Price {  get; set; }
        public string AuthorName { get; set; }

    }
}
