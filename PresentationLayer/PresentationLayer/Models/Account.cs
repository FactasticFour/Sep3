namespace PresentationLayer.Models
{
    public class Account
    {
        
        public int accountId { get; set; }
        public string applicationPassword { get; set; }
        public int balance { get; set; }
        public ViaEntity viaEntity { get; set; }

        public Account(int accountId, string applicationPassword, int balance, ViaEntity viaEntity)
        {
            this.accountId = accountId;
            this.applicationPassword = applicationPassword;
            this.balance = balance;
            this.viaEntity = viaEntity;
        }
    }
}