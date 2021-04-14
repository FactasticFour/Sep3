package dk.via.sep3.group1.applicationlogic.model.dao;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import dk.via.sep3.group1.applicationlogic.model.User;
import org.springframework.stereotype.Service;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;

@Service
public class UserDAOImpl implements UserDAO {

    private String usersFilePath = "users.json";
    private ArrayList<User> usersList;

    private ObjectMapper mapper;

    public UserDAOImpl() {
        mapper = new ObjectMapper();
        usersList = new ArrayList<>();
        readUsers(usersFilePath);
    }

    private void readUsers(String file) {
        try {
            usersList = mapper.readValue(new File(file), new TypeReference<>() {
            });
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public User getUserById(int id) {
        for (User user : usersList) {
            if (user.getId() == id){
                return user;
            }
        }

        return null;
    }
}
