package dk.via.sep3.group1.applicationlogic.dao.impl;

import dk.via.sep3.group1.applicationlogic.dao.DbSeedingDAO;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import dk.via.sep3.group1.applicationlogic.networking.DataClientImpl;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class DbSeedingDAOImpl implements DbSeedingDAO {

    @Autowired
    DataClientImpl dataClient;

    @Override
    public void seedDatabase() {

    }
}
