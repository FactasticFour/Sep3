namespace PresentationLayer.Models
{
    public class Account
    {
        
        public int AccountId { get; set; }
        public string ApplicationPassword { get; set; }
        public int Balance { get; set; }
        public ViaEntity ViaEntity { get; set; }

        public Account(int accountId, string applicationPassword, int balance, ViaEntity viaEntity)
        {
            AccountId = accountId;
            ApplicationPassword = applicationPassword;
            Balance = balance;
            ViaEntity = viaEntity;
        }
    }
}