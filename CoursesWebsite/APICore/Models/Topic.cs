using System;
using System.Collections.Generic;

namespace APICore.Models
{
    public class Topic: Entity
    {
        private List<Lesson> _lessons;
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public IEnumerable<Lesson> Lessons => _lessons;
        public Topic(string name, string description)
        {
            SetName(name);
            SetDescription(description);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Name cannot be empty");
            Name = name;
        }
        public void SetDescription(string description)
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
        public void AddLesson(List<Lesson> lessons)
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
