namespace PresentationLayer.Models
{
    public class Facility : ViaEntity
    {
        public string Name { get; set; }
        public Campus Campus { get; set; }
        public Account Account { get; set; }

        public Facility(int viaId, string password, string name, Campus campus, Account account) : base(viaId, password)
        {
            Name = name;
            Campus = campus;
            Account = account;
        }
    }
}