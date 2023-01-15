using System;

namespace APICore.Models
{
    public class Lesson : Entity
    {
        public string LessonName { get; protected set; }
        public string LessonDescription { get; protected set; }
        //public byte[] Video { get;protected set; } check the best way to save Video file
        private Lesson()
        {

        }
        public Lesson(string lessonName, string lessonDescription)
        {
            SetName(lessonName);
            SetDescription(lessonDescription);
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
    }
}
