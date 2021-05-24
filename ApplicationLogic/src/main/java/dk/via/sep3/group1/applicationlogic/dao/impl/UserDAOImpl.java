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

    public UserDAOImpl() {

    }

    @Override
    public User getUserById(int id) {
        // TODO remove autoWired and initialize the object everytime when you call method
        DataClient dataClient = new DataClientImpl();
        User user = dataClient.getUser(id);
        if (user != null)
        return user;
        else
            throw new RuntimeException("User null in DAO");
    }
}

