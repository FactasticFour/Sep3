package dk.via.sep3.group1.applicationlogic.service;

import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.model.CreditCard;

public interface CreditCardService {
    boolean addCreditCardToAccount(CreditCard creditCard);
}
