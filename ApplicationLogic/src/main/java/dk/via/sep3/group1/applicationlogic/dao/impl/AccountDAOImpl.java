package dk.via.sep3.group1.applicationlogic.dao.impl;

import dk.via.sep3.group1.applicationlogic.dao.AccountDAO;
import dk.via.sep3.group1.applicationlogic.model.Account;
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
    public Account getRoleByUsername(String username) {
        Request request = null;
        request.setPayload(Serialization.serialize(username));
        request.setType(request.GET_ACCOUNT_BY_USERNAME);

        Reply reply = dataClient.handleRequest(request);
        if (reply.getType().equals("ACCOUNT_BY_USERNAME")) {
            Account account = Serialization.deserialize(reply.getPayload(), Account.class);
            return account;
        } else {
            throw new NullPointerException(reply.BAD_REQUEST);
        }
    }
}
