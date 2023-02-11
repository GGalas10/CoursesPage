using Courses.Core.Value_Object;

namespace Courses.Core.Models
{
    public class Course :Entity
    {
        #region Properties
        private HashSet<Topic> _topics;
        private HashSet<Guid> _categories;
        public Name Name { get; protected set; }
        public Name Description { get; protected set; }
        public Name Author { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DigitalItem Picutre { get; protected set; }
        public IEnumerable<Topic> Topics => _topics;
        public IEnumerable<Guid> Categories => _categories;
        #endregion
        #region Constructors
        private Course() { }
        public Course(string name, string description, string author, byte[] picture):base()
        {
            _topics= new HashSet<Topic>();
            _categories= new HashSet<Guid>();
            SetName(name);
            SetDescription(description);
            SetAuthor(author);
            SetPicture(picture);
            CreatedAt = DateTime.UtcNow;
            State = State.Active;
        }

        #endregion
        #region Methods
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetDescription(string description)
        {
            Description = description;
        }
        public void SetAuthor(string author)
        {
            Author = author;
        }
        public void AddTopic(Topic topic)
        {
            _topics.Add(topic);
        }
        public void AddTopic(List<Topic> topics)
        {
            foreach(var topic in topics)
            _topics.Add(topic);
        }
        public void AddCategory(Guid Category)
        {
            _categories.Add(Category);
        }
        public void RemoveCategory(Guid Category)
        {
            _categories.Remove(Category);
        }
        public void SetPicture(DigitalItem Picture)
        {
            this.Picutre= Picture;
        }
        #endregion
    }
}