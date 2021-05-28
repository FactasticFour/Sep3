package dk.via.sep3.group1.applicationlogic.dao.impl;

import dk.via.sep3.group1.applicationlogic.dao.CreditCardDAO;
import dk.via.sep3.group1.applicationlogic.model.CreditCard;
import dk.via.sep3.group1.applicationlogic.model.User;
import dk.via.sep3.group1.applicationlogic.networking.DataClientImpl;
import dk.via.sep3.group1.applicationlogic.shared.Reply;
import dk.via.sep3.group1.applicationlogic.shared.Request;
import dk.via.sep3.group1.applicationlogic.shared.Serialization;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class CreditCardDAOImpl implements CreditCardDAO {
    @Autowired
    DataClientImpl dataClient;

    @Override
    public String addCreditCardToAccount(CreditCard creditCard) throws IllegalAccessException {
        Request request = new Request();
        request.setPayload(Serialization.serialize(creditCard));
        request.setType(request.ADD_CREDIT_CARD_TO_ACCOUNT);
        Reply reply = dataClient.handleRequest(request);
        System.out.println("XXXXXXXXXXX");
        System.out.println(reply.getPayload());
        System.out.println(reply.getType());
        if(reply.getType().equals(reply.BAD_REQUEST)){
            throw new IllegalAccessException(reply.getPayload());
           
        }
        else {
            return Serialization.deserialize(reply.getPayload(), String.class);
        }

    }
}
