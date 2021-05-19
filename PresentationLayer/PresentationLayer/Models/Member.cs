namespace PresentationLayer.Models
{
    public class Member : ViaEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Cpr { get; set; }
        public Account Account { get; set; }

        public Member(int viaId, string password, string firstName, string lastName, long cpr, Account account) : base(viaId, password)
        {
            FirstName = firstName;
            LastName = lastName;
            Cpr = cpr;
            Account = account;
        }
    }
}