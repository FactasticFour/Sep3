package dk.via.sep3.group1.applicationlogic.model.dao;

import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.stereotype.Service;

@Repository
public class DbSeedingDAOImpl implements DbSeedingDAO{

    @Autowired
    DataClient dataClient;

    @Override
    public void seedDatabase() {
        dataClient.seedDatabase();
    }
}
