using System;

namespace APICore.Models
{
    public class Lesson : Entity
    {
        public string LessonName { get; protected set; }
        public string LessonDescription { get; protected set; }
        public byte[] Video { get;protected set; }
        public int LessonNumber { get; protected set; }
        public Lesson(string lessonName, string lessonDescription, byte[] video,int lessonNumber) : base()
        {
            SetName(lessonName);
            SetDescription(lessonDescription);
            SetVideo(video);
            SetLessonNumber(lessonNumber);
        }      
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
    }
}
