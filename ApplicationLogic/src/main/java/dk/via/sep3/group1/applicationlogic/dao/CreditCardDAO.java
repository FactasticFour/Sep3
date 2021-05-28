package dk.via.sep3.group1.applicationlogic.dao;

import dk.via.sep3.group1.applicationlogic.model.CreditCard;

public interface CreditCardDAO {
    String addCreditCardToAccount(CreditCard creditCard) throws IllegalAccessException;
}
