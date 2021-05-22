package dk.via.sep3.group1.applicationlogic.model.dao.impl;

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
        return null;
    }
}
