package dk.via.sep3.group1.applicationlogic.service.impl;

import dk.via.sep3.group1.applicationlogic.model.User;
import dk.via.sep3.group1.applicationlogic.dao.UserDAO;
import dk.via.sep3.group1.applicationlogic.service.UserService;
import dk.via.sep3.group1.applicationlogic.model.dao.UserDAO;
import dk.via.sep3.group1.applicationlogic.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class UserServiceImpl implements UserService {

    @Autowired
    UserDAO userDAO;

    @Override
    public User getUserById(int id) {
        return userDAO.getUserById(id);
    }
}
