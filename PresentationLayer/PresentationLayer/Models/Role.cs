namespace PresentationLayer.Models
{
    public class Role
    {
        public int RoleId { get; set; }
    
        public Account Account { get; set; }
       
        public string RoleType { get; set; }

        public Role(int roleId, Account account, string roleType)
        {
            RoleId = roleId;
            Account = account;
            RoleType = roleType;
        }
    }
}