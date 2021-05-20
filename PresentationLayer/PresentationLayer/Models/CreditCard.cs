namespace PresentationLayer.Models
{
    public class CreditCard
    {
       public string CreditCardNumber { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string ExpirationMonth { get; set; }
       public string ExpirationYear { get; set; }
       public int SecurityCode { get; set; }
       public int AmountOfMoney { get; set; }
       public Account Account { get; set; }

       public CreditCard(string creditCardNumber, string firstName, string lastName, string expirationMonth, string expirationYear, int securityCode, int amountOfMoney, Account account)
       {
           CreditCardNumber = creditCardNumber;
           FirstName = firstName;
           LastName = lastName;
           ExpirationMonth = expirationMonth;
           ExpirationYear = expirationYear;
           SecurityCode = securityCode;
           AmountOfMoney = amountOfMoney;
           Account = account;
       }
    }
}