namespace PresentationLayer.Models
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Cpr { get; set; }
        public Account Account { get; set; }

        public Member(string firstName, string lastName, long cpr, Account account)
        {
            FirstName = firstName;
            LastName = lastName;
            Cpr = cpr;
            Account = account;
        }
    }
}