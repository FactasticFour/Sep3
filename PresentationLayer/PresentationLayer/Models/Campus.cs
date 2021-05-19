namespace PresentationLayer.Models
{
    public class Campus
    {
    
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Name { get; set; }

        public Campus(string city, string street, string postCode, string name)
        {
            City = city;
            Street = street;
            PostCode = postCode;
            Name = name;
        }
    }
}