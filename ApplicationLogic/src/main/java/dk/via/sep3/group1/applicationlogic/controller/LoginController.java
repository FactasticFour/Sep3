package dk.via.sep3.group1.applicationlogic.controller;

import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.service.LoginService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/login")
public class LoginController {

    @Autowired
    LoginService loginService;


    @GetMapping()
    public Account validateUser(@RequestParam("username") String username, @RequestParam("password") String password) {
        System.out.println("Controller - Username from client: " + username);
        System.out.println("Controller - Password from client: " + password);

        Account account = loginService.validateAccount(password, username);

        // checking if caring default object
        if (account.getAccountId() == 0) {
            System.out.println("Role object is default, account not found");
            return account;
        } else {
            System.out.println("Role to be sent to client: " + account.getAccountType() + "\n" + account.getAccountId() + "\n" + account.getViaEntity().getViaId());
            return account;
        }

    }
}
