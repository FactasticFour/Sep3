package dk.via.sep3.group1.applicationlogic.dao.impl;

import dk.via.sep3.group1.applicationlogic.model.Facility;
import dk.via.sep3.group1.applicationlogic.model.Member;
import dk.via.sep3.group1.applicationlogic.model.ViaEntity;
import dk.via.sep3.group1.applicationlogic.dao.AccountDAO;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
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

    @Override
    public ViaEntity getViaEntityWithId(int id) {
        System.out.println("account dao in action babeh");

        Request request = new Request();
        request.setPayload(Serialization.serialize(id));
        request.setType(request.GET_ENTITY_WITH_ID);

        Reply reply = dataClient.handleRequest(request);

        if (reply.getType().equals(reply.SEND_ENTITY)){
            ViaEntity viaEntity = Serialization.deserialize(reply.getPayload(), ViaEntity.class);
            return viaEntity;
        }
        else throw new NullPointerException(reply.BAD_REQUEST);
    }
}
