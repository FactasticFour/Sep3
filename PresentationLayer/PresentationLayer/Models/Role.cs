namespace PresentationLayer.Models
{
    public class Role
    {
        public int RoleId { get; set; }
    
        public Account Account { get; set; }
       
        public string RoleType { get; set; }
    }
}