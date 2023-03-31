using Courses.Core.Models.Common;
using Courses.Core.Value_Object;
using System.Xml.Linq;

namespace Courses.Core.Models.Course
{
    public class Course : Entity
    {
        #region Properties
        private HashSet<Topic> _topics;
        public Name Name { get; protected set; }
        public Name Description { get; protected set; }
        public double Price { get; protected set; }
        public Name Author { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DigitalItem Picutre { get; protected set; }
        public ICollection<Topic> Topics => _topics;
        #endregion
        #region Constructors
        private Course() { }
        public Course(string name, string description, string author, byte[] picture, double price) : base()
        {
            _topics = new HashSet<Topic>();
            SetName(name);
            SetDescription(description);
            SetPrice(price);
            SetAuthor(author);
            SetPicture(picture);
            CreatedAt = DateTime.UtcNow;
            State = State.Active;
        }

        #endregion
        #region Methods
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
        public void SetAuthor(string author)
        {
            if (string.IsNullOrEmpty(author))
                throw new Exception("Author cannot be empty");
            Author = author;
        }
        public void AddTopic(Topic topic)
        {
            _topics.Add(topic);
        }
        public void AddTopic(List<Topic> topics)
        {
            foreach (var topic in topics)
                _topics.Add(topic);
        }
        public void SetPicture(DigitalItem Picture)
        {
            Picutre = Picture;
        }
        public void SetPrice(double price)
        {
            if (price <= 0)
                throw new Exception("Price cannot be smaller than or equal 0");
            Price = price;
        }
        #endregion
    }
}