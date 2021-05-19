namespace PresentationLayer.Models
{
    public class Account
    {
        
        public int AccountId { get; set; }
        public string ApplicationPassword { get; set; }
        public int Balance { get; set; }
        public ViaEntity ViaEntity { get; set; }
    }
}