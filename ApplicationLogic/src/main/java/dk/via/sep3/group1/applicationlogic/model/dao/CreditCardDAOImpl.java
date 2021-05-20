package dk.via.sep3.group1.applicationlogic.model.dao;

import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.model.CreditCard;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class CreditCardDAOImpl implements CreditCardDAO {

    @Autowired
    DataClient dataClient;
    public CreditCardDAOImpl(){}

    @Override
    public void addCreditCardToAccount(CreditCard creditCard) {
        dataClient.addCreditCardToAccount(creditCard);
    }
}
