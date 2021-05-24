package dk.via.sep3.group1.applicationlogic.model.dao.impl;

import dk.via.sep3.group1.applicationlogic.model.Facility;
import dk.via.sep3.group1.applicationlogic.model.Member;
import dk.via.sep3.group1.applicationlogic.model.ViaEntity;
import dk.via.sep3.group1.applicationlogic.model.dao.AccountDAO;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class AccountDAOImpl implements AccountDAO {

    @Autowired
    DataClient dataClient;

    @Override
    public ViaEntity getViaEntityWithId(int id) {
        System.out.println("account dao in action babeh");
        return dataClient.getViaEntityById(id);
    }

    @Override
    public Member getViaMemberById(int id) {
        return dataClient.getViaMemberById(id);
    }

    @Override
    public Facility getViaFacilityById(int id) {
        return dataClient.getViaFacilityById(id);
    }

}
