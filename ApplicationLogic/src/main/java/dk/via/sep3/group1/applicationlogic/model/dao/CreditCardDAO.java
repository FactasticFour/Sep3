package dk.via.sep3.group1.applicationlogic.model.dao;

import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.model.CreditCard;

public interface CreditCardDAO {
    void addCreditCardToAccount(CreditCard creditCard);
}