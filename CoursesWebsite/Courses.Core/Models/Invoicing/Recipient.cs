using Courses.Core.Models.Common;

namespace Courses.Core.Models.Invoicing
{
    public class Recipient
    {
        public Guid Id { get; protected set; }
        public Adress DeliveryAdress { get;protected set; }
    }
}
