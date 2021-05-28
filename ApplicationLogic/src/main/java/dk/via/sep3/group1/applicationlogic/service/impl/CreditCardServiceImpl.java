package dk.via.sep3.group1.applicationlogic.service.impl;

import dk.via.sep3.group1.applicationlogic.dao.CreditCardDAO;
import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.model.CreditCard;
import dk.via.sep3.group1.applicationlogic.service.CreditCardService;
import dk.via.sep3.group1.applicationlogic.shared.Reply;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class CreditCardServiceImpl implements CreditCardService {

    @Autowired
    CreditCardDAO creditCardDAO;

    @Override
    public boolean addCreditCardToAccount(CreditCard creditCard) {
        System.out.println(creditCard.toString());
        String isAdded = creditCardDAO.addCreditCardToAccount(creditCard);
        if (creditCard.getCreditCardNumber().length() != 16 || creditCard.getFirstName() == null || creditCard.getLastName() == null ||
                creditCard.getSecurityCode() < 0 || creditCard.getSecurityCode() > 999 || !isAdded.equals("CARD_ADDED")) {
            return false;
        } else {
            return true;
        }
    }

    @Override
    public boolean checkCreditCard(int id) {
        return creditCardDAO.checkCreditCard(id);
    }

    @Override
    public boolean depositMoney(Account account) {
        return creditCardDAO.depositMoney(account);
    }
}