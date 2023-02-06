using APICore.Object_Value;
using System;
using System.Collections.Generic;

namespace Courses.Core.Models
{
    public class Topic: Entity
    {
        private List<Lesson> _lessons;
        public Name Name { get; protected set; }
        public Name Description { get; protected set; }
        public IEnumerable<Lesson> Lessons => _lessons;
        public Topic(Name name, Name description)
        {
            _lessons= new List<Lesson>();
            SetName(name);
            SetDescription(description);
        }

        public void SetName(Name name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Name cannot be empty");
            Name = name;
        }
        public void SetDescription(Name description)
        {
            if (string.IsNullOrEmpty(description))
                throw new Exception("Description cannot be empty");
            Description = description;
        }
        public void AddLesson(Lesson lesson)
        {
            if (lesson == null) 
                throw new Exception("Lesson cannot be empty");
            _lessons.Add(lesson);
        }
        public void AddLessons(List<Lesson> lessons)
        {
            if (lessons == null)
                throw new Exception("Lesson cannot be empty");
            foreach (Lesson lesson in lessons)
            {
                _lessons.Add(lesson);
            }           
        }
    }
}
