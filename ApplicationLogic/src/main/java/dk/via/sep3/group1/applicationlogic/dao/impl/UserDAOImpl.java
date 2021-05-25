package dk.via.sep3.group1.applicationlogic.dao.impl;
import dk.via.sep3.group1.applicationlogic.model.User;
import dk.via.sep3.group1.applicationlogic.dao.UserDAO;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import dk.via.sep3.group1.applicationlogic.networking.DataClientImpl;
import org.springframework.stereotype.Repository;

@Repository
public class UserDAOImpl implements UserDAO {

    public UserDAOImpl() {
    }

    @Override
    public User getUserById(int id) {
        // Initialize a new socket for every request/method call from DAOImpl
        DataClient dataClient = new DataClientImpl();

        User user = dataClient.getUser(id);
        if (user != null)
        return user;
        else
            throw new RuntimeException("User null in DAO");
    }
}
