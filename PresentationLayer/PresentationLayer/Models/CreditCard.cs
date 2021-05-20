namespace PresentationLayer.Models
{
    public class CreditCard
    {
       public string creditCardNumber { get; set; }
       public string firstName { get; set; }
       public string lastName { get; set; }
       public string expirationMonth { get; set; }
       public string expirationYear { get; set; }
       public int securityCode { get; set; }
       public int amountOfMoney { get; set; }
       public Account account { get; set; }

       public CreditCard(string creditCardNumber, string firstName, string lastName, string expirationMonth, string expirationYear, int securityCode, int amountOfMoney, Account account)
       {
           this.creditCardNumber = creditCardNumber;
           this.firstName = firstName;
           this.lastName = lastName;
           this.expirationMonth = expirationMonth;
           this.expirationYear = expirationYear;
           this.securityCode = securityCode;
           this.amountOfMoney = amountOfMoney;
           this.account = account;
       }

       public CreditCard()
       {
           
       }
    }
}