package dk.via.sep3.group1.applicationlogic.dao.impl;

import dk.via.sep3.group1.applicationlogic.dao.AccountDAO;
import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import dk.via.sep3.group1.applicationlogic.shared.Reply;
import dk.via.sep3.group1.applicationlogic.shared.Request;
import dk.via.sep3.group1.applicationlogic.shared.Serialization;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.serializer.support.SerializationFailedException;
import org.springframework.stereotype.Repository;

@Repository
public class AccountDAOImpl implements AccountDAO {

    @Autowired
    DataClient dataClient;

    @Override
    public boolean checkAccountWithViaId(int viaId) {
        Request request = new Request();
        request.setPayload(Serialization.serialize(viaId));
        request.setType(request.GET_ACCOUNT_WITH_VIA_ID);

        Reply reply = null;
        try {
            reply = dataClient.handleRequest(request);
            return true;
        } catch (Exception e) {
            return false;
        }
    }

    @Override
    public Account addAccount(Account accountToCreate) {
        Request request = new Request();
        request.setPayload(Serialization.serialize(accountToCreate));
        request.setType(request.ADD_ACCOUNT);

        Reply reply = dataClient.handleRequest(request);

        if (reply.getType().equals(reply.ACCOUNT_ADDED)) {
            return accountToCreate;
        }
        return null;
    }

    @Override
    public float getAccountBalance(int accountId) {
        Request request = new Request();

        request.setPayload(Serialization.serialize(accountId));
        request.setType(request.GET_ACCOUNT_BY_ACCOUNT_ID);
        System.out.println(request.getPayload());
        Reply reply = dataClient.handleRequest(request);
        Account account = Serialization.deserialize(reply.getPayload(), Account.class);
        System.out.println(account.getBalance());
        return account.getBalance();

    }

    @Override
    public Account getAccountByUsername(String username) {
        Request request = new Request();
        request.setPayload(Serialization.serialize(username));
        request.setType(request.GET_ACCOUNT_BY_USERNAME);

        Reply reply = dataClient.handleRequest(request);
        return Serialization.deserialize(reply.getPayload(), Account.class);
    }

}
