namespace Courses.Core.Models.Commons
{
    public class Address
    {
        public Guid Id { get; protected set; }
        public string Street { get; protected set; }
        public string City { get; protected set; }
        public string PostalCode { get; protected set; }
        public string StreetNumber { get; protected set; }
        public string? HomeNumber { get; protected set; }
        private Address() { }
        public Address(string street, string city, string postalCode, string streetNumber, string? homeNumber)
        {
            Id = Guid.NewGuid();
            SetStreet(street);
            SetCity(city);
            SetPostalCode(postalCode);
            SetStreetNumber(streetNumber);
            SetHomeNumber(homeNumber);
        }
        public void SetStreet(string street)
        {
            if (string.IsNullOrEmpty(street))
                throw new Exception("Street cannot be empty");
            Street = street.Trim();
        }
        public void SetCity(string city)
        {
            if (string.IsNullOrEmpty(city))
                throw new Exception("City cannot be empty");
            City = city.Trim();
        }
        public void SetPostalCode(string postalCode)
        {
            if (string.IsNullOrEmpty(postalCode))
                throw new Exception("Postal code cannot be empty");
            if (postalCode.Length > 7 && postalCode.Length < 4)
                throw new Exception("Postal code is wrong");
            if (postalCode.Length != 7 && postalCode[3] != '-')
                throw new Exception("Postal code is wrong");
            PostalCode = postalCode.Trim();
        }
        public void SetStreetNumber(string streetNumber)
        {
            if (string.IsNullOrEmpty(streetNumber))
                throw new Exception("Street number cannot be empty");
            StreetNumber = streetNumber.Trim();
        }
        public void SetHomeNumber(string? homeNumber)
        {
            if (string.IsNullOrEmpty(homeNumber))
                homeNumber = string.Empty;
            homeNumber = homeNumber.Trim();
        }
    }
}
