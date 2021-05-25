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
        DataClient dataClient = new DataClientImpl();
        //return dataClient.getViaEntityById(id);
        return null;
    }

    @Override
    public Member getViaMemberById(int id) {
        Request request = new Request();
        request.setPayload(Serialization.serialize(id));
        request.setType(request.GET_MEMBER_BY_ID);
        Reply reply = dataClient.handleRequest(request);
        if (reply.getType().equals(reply.SEND_MEMBER)){
            Member member = Serialization.deserialize(reply.getPayload(), Member.class);
            return member;
        }
        else throw new NullPointerException(reply.BAD_REQUEST);
    }

    @Override
    public Facility getViaFacilityById(int id) {
        DataClient dataClient = new DataClientImpl();
        //return dataClient.getViaFacilityById(id);
        return null;
    }

}
