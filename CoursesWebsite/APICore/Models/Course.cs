using System;
using System.Collections.Generic;

namespace APICore.Models
{
    public class Course :Entity
    {
        #region Properties
        private List<Topic> _topics;
        private List<Guid> _categories;
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string Author { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public State state { get; protected set; }
        public IEnumerable<Topic> Topics => _topics;
        public IEnumerable<Guid> Categories => _categories;
        #endregion
        #region Constructors
        public Course(string name, string description, string author):base()
        {
            SetName(name);
            SetDescription(description);
            SetAuthor(author);
            CreatedAt = DateTime.UtcNow;
            state = State.Active;
        }

        #endregion
        #region Methods
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Name cannot be empty");
            }
            Name = name;
        }
        public void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new Exception("Description cannot be empty");
            }
            Description = description;
        }
        public void SetAuthor(string author)
        {
            if (string.IsNullOrEmpty(author))
            {
                throw new Exception("Author cannot be empty");
            }
            Author = author;
        }
        public void AddTopic(Topic topic)
        {
            if(topic == null)
            {
                throw new Exception("Topic cannot be empty");
            }
            _topics.Add(topic);
        }
        public void AddTopic(List<Topic> topics)
        {
            if (topics == null)
            {
                throw new Exception("Topic cannot be empty");
            }
            foreach(var topic in topics)
            _topics.Add(topic);
        }
        public void SetState(State Setstate)
        {
            state = Setstate;
        }
        public void AddCategory(Guid Category)
        {
            if (Category == Guid.Empty)
                throw new Exception("Category cannot be empty");
            _categories.Add(Category);
        }
        public void RemoveCategory(Guid Category)
        {
            if (Category == Guid.Empty)
                throw new Exception("Category cannot be empty");
            _categories.Remove(Category);
        }
        #endregion
    }
}