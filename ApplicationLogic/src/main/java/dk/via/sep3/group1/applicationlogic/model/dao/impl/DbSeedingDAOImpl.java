package dk.via.sep3.group1.applicationlogic.model.dao.impl;

import dk.via.sep3.group1.applicationlogic.model.dao.DbSeedingDAO;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class DbSeedingDAOImpl implements DbSeedingDAO {

    @Autowired
    DataClient dataClient;

    @Override
    public void seedDatabase() {
        dataClient.seedDatabase();
    }
}
