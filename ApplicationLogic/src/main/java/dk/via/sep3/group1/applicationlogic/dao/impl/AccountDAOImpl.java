package dk.via.sep3.group1.applicationlogic.dao.impl;

import dk.via.sep3.group1.applicationlogic.model.Facility;
import dk.via.sep3.group1.applicationlogic.model.Member;
import dk.via.sep3.group1.applicationlogic.model.ViaEntity;
import dk.via.sep3.group1.applicationlogic.dao.AccountDAO;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import dk.via.sep3.group1.applicationlogic.networking.DataClientImpl;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class AccountDAOImpl implements AccountDAO {

    @Override
    public ViaEntity getViaEntityWithId(int id) {
        System.out.println("account dao in action babeh");
        DataClient dataClient = new DataClientImpl();
        return dataClient.getViaEntityById(id);
    }

    @Override
    public Member getViaMemberById(int id) {
        DataClient dataClient = new DataClientImpl();
        return dataClient.getViaMemberById(id);
    }

    @Override
    public Facility getViaFacilityById(int id) {
        DataClient dataClient = new DataClientImpl();
        return dataClient.getViaFacilityById(id);
    }

}
