package dk.via.sep3.group1.applicationlogic.dao.impl;

import com.fasterxml.jackson.databind.ObjectMapper;
import dk.via.sep3.group1.applicationlogic.model.User;
import dk.via.sep3.group1.applicationlogic.dao.UserDAO;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import dk.via.sep3.group1.applicationlogic.networking.DataClientImpl;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;

@Repository
public class UserDAOImpl implements UserDAO {

    private String usersFilePath = "users.json";
    private ArrayList<User> usersList;
    private ObjectMapper mapper;

    @Autowired
    DataClient dataClient;

    public UserDAOImpl() {
        mapper = new ObjectMapper();
        usersList = new ArrayList<>();
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
