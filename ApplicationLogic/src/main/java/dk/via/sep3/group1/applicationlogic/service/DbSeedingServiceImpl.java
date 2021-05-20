package dk.via.sep3.group1.applicationlogic.service;

import dk.via.sep3.group1.applicationlogic.model.dao.DbSeedingDAO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class DbSeedingServiceImpl implements DbSeedingService{

    @Autowired
    DbSeedingDAO dbSeedingDAO;

    @Override
    public void seedDatabase() {
        dbSeedingDAO.seedDatabase();
    }
}
