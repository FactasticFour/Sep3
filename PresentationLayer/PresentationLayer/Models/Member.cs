namespace PresentationLayer.Models
{
    public class Member : ViaEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Cpr { get; set; }
        public Account Account { get; set; }
    }
}