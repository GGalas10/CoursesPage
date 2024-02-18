namespace Courses.Core.Models.Commons
{
    public enum State
    {
        Active,
        Inactive,
        Deleted
    }
    public enum CourseState
    {
        Draft = 0,
        WaitForAccept = 1,
        Accepted = 2,
        Inactive = 3,
        Deleted = 4,
    }
}
