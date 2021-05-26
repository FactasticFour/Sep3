package dk.via.sep3.group1.applicationlogic.dao.impl;

import dk.via.sep3.group1.applicationlogic.dao.AccountDAO;
import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.networking.DataClientImpl;
import dk.via.sep3.group1.applicationlogic.shared.Reply;
import dk.via.sep3.group1.applicationlogic.shared.Request;
import dk.via.sep3.group1.applicationlogic.shared.Serialization;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.serializer.support.SerializationFailedException;
import org.springframework.stereotype.Repository;

@Repository
public class AccountDAOImpl implements AccountDAO {
    @Autowired
    DataClientImpl dataClient;

    public AccountDAOImpl() {
    }

    @Override
    public Account getRoleByUsername(String username) {
        Request request = new Request();
        request.setPayload(Serialization.serialize(username));
        request.setType(request.GET_ACCOUNT_BY_USERNAME);

        Reply reply = dataClient.handleRequest(request);

        if (reply.getType().equals(reply.ACCOUNT_BY_USERNAME)) {
            return Serialization.deserialize(reply.getPayload(), Account.class);
        } else {
            try {
                String deserialize = Serialization.deserialize(reply.getPayload(), String.class);
                throw new Exception(deserialize);
            } catch (Exception e) {
                e.printStackTrace();
                throw new SerializationFailedException("Reply could not be deserialized");
            }
        }
    }
}
