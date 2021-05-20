package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class CreditCard {

    @JsonProperty("creditCardNumber")
    public String creditCardNumber;
    @JsonProperty("firstName")
    public String firstName;
    @JsonProperty("lastName")
    public String lastName;
    @JsonProperty("expirationMonth")
    public String expirationMonth;
    @JsonProperty("expirationYear")
    public String expirationYear;
    @JsonProperty("securityCode")
    public int securityCode;
    @JsonProperty("amountOfMoney")
    public int amountOfMoney = 9000000;
    @JsonProperty("account")
    public Account account;


}
