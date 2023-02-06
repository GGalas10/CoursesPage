using APICore.Object_Value;
using System;

namespace Courses.Core.Models
{
    public class Lesson : Entity
    {
        #region Properties
        public Name LessonName { get; protected set; }
        public Name LessonDescription { get; protected set; }
        public byte[] Video { get;protected set; }
        public int LessonNumber { get; protected set; }
        #endregion
        #region ctor
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
            if (string.IsNullOrEmpty(name))
                throw new Exception("Name cannot be empty");
            LessonName = name;
        }
        public void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new Exception("Name cannot be empty");
            LessonDescription = description;
        }
        public void SetVideo(byte[] video)
        {
            if (video == null) 
                throw new Exception("Video file cannot be empty");
            Video = video;
        }
        public void SetLessonNumber(int lessonNumber)
        {
            if (lessonNumber < 0) throw new Exception("Number cannot be less than zero");
            LessonNumber = lessonNumber;
        }
        #endregion
    }
}
