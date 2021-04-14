package dk.via.sep3.group1.applicationlogic.controller;

import dk.via.sep3.group1.applicationlogic.model.User;
import dk.via.sep3.group1.applicationlogic.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/users")
public class UserController {

    @Autowired
    UserService userService;

    @GetMapping("{id}")
    public User getUserById(@PathVariable int id){
        return userService.getUserById(id);
    }
}
