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
    public void addCreditCardToAccount(CreditCard creditCard) {
        creditCardDAO.addCreditCardToAccount(creditCard);
    }
}