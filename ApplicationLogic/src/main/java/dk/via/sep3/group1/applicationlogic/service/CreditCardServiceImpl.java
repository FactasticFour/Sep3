package dk.via.sep3.group1.applicationlogic.service;

import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.model.CreditCard;
import dk.via.sep3.group1.applicationlogic.model.dao.CreditCardDAO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class CreditCardServiceImpl implements CreditCardService{

    @Autowired
    CreditCardDAO creditCardDAO;

    @Override
    public boolean addCreditCardToAccount(CreditCard creditCard) {
        if(creditCard.creditCardNumber.length() != 16 || creditCard.firstName == null || creditCard.lastName == null ||
                  creditCard.securityCode < 100 || creditCard.securityCode > 999){
return false;
        }
        else {
            creditCardDAO.addCreditCardToAccount(creditCard);
            return true;
        }
    }
}