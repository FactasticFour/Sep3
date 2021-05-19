package dk.via.sep3.group1.applicationlogic.model.dao;

import com.fasterxml.jackson.databind.ObjectMapper;
import dk.via.sep3.group1.applicationlogic.model.User;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.stereotype.Service;

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
        User user = dataClient.getUser(id);
        if (user != null)
        return user;
        else
            throw new RuntimeException("User null in DAO");
    }
}
