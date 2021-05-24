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
    }
}