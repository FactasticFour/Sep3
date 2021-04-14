package dk.via.sep3.group1.applicationlogic.model.dao;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import dk.via.sep3.group1.applicationlogic.model.User;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;

public class UserDAOImpl implements UserDAO {

    private String usersFilePath = "users.json";
    private ArrayList<User> usersList;

    private ObjectMapper mapper;

    public UserDAOImpl() {
        mapper = new ObjectMapper();
        usersList = new ArrayList<>();
    }

    private void readUsers(String file) {
        File usersFile = new File(file);
        try {
            usersList = mapper.readValue(usersFile, new TypeReference<>() {
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
