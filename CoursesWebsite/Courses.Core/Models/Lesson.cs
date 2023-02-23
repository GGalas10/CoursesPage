using Courses.Core.Value_Object;

namespace Courses.Core.Models
{
    public class Lesson : Entity
    {
        #region Properties
        public Name LessonName { get; protected set; }
        public Name LessonDescription { get; protected set; }
        public DigitalItem Video { get;protected set; }
        public Number LessonNumber { get; protected set; }
        public virtual Topic Topic { get; protected set; }
        #endregion
        #region Constructors
        private Lesson() { }
        public Lesson(string lessonName, string lessonDescription, byte[] video,int lessonNumber) : base()
        {
            SetName(lessonName);
            SetDescription(lessonDescription);
            SetVideo(video);
            SetLessonNumber(lessonNumber);
            State = State.Active;
        }
        #endregion
        #region Methods
        public void SetName(string name)
        {
            LessonName = name;
        }
        public void SetDescription(string description)
        {
            LessonDescription = description;
        }
        public void SetVideo(DigitalItem video)
        {
            Video = video;
        }
        public void SetLessonNumber(int lessonNumber)
        {
            LessonNumber = lessonNumber;
        }
        #endregion
    }
}
