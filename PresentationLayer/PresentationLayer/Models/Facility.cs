namespace PresentationLayer.Models
{
    public class Facility
    {
        public string Name { get; set; }
        public Campus Campus { get; set; }
        public Account Account { get; set; }

        public Facility(string name, Campus campus, Account account)
        {
            Name = name;
            Campus = campus;
            Account = account;
        }
        
        
    }
}