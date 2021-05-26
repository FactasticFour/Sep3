package dk.via.sep3.group1.applicationlogic.dao.impl;

import dk.via.sep3.group1.applicationlogic.dao.AccountDAO;
import dk.via.sep3.group1.applicationlogic.model.User;
import dk.via.sep3.group1.applicationlogic.networking.DataClientImpl;
import dk.via.sep3.group1.applicationlogic.shared.Reply;
import dk.via.sep3.group1.applicationlogic.shared.Request;
import dk.via.sep3.group1.applicationlogic.shared.Serialization;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class AccountDAOImpl implements AccountDAO {

    @Autowired
    DataClientImpl dataClient;

    public AccountDAOImpl() {
    }

    @Override
    public float getAccountBalance(int id) {
        Request request = new Request();
        request.setPayload(Serialization.serialize(id));
        request.setType(request.GET_ACCOUNT_BALANCE);
        Reply reply = dataClient.handleRequest(request);
        if (reply.getType().equals(reply.SEND_ACCOUNT_BALANCE)) {
            float balance = Serialization.deserialize(reply.getPayload(), float.class);
            return balance;
        }
        else {
            throw new NullPointerException(reply.BAD_REQUEST);
        }
    }
}
