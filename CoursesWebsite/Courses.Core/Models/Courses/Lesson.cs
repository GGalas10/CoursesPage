using Courses.Core.Models.Commons;
using Courses.Core.Value_Object;

namespace Courses.Core.Models.Courses
{
    public class Lesson : Entity
    {
        #region Properties
        public Name LessonName { get; protected set; }
        public Name LessonDescription { get; protected set; }
        public DigitalItem Video { get; protected set; }
        public Number LessonNumber { get; protected set; }
        public virtual Topic Topic { get; protected set; }
        #endregion
        #region Constructors
        private Lesson() { }
        public Lesson(string lessonName, string lessonDescription, byte[]? video, int lessonNumber) : base()
        {
            SetName(lessonName);
            SetDescription(lessonDescription);
            if (video != null)
                SetVideo(video);
            SetLessonNumber(lessonNumber);
            State = State.Active;
        }
        #endregion
        #region Methods
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Name cannot be empty");
            LessonName = name;
        }
        public void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new Exception("Description cannot be empty");
            LessonDescription = description;
        }
        public void SetVideo(DigitalItem video)
        {
            Video = video;
        }
        public void SetLessonNumber(int lessonNumber)
        {
            if (lessonNumber <= 0)
                throw new Exception("Lesson number cannot be less or equal 0");
            LessonNumber = lessonNumber;
        }
        #endregion
    }
}
