package dk.via.sep3.group1.applicationlogic.controller;

import dk.via.sep3.group1.applicationlogic.model.ViaEntity;
import dk.via.sep3.group1.applicationlogic.service.AccountService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/account")
public class AccountController {

    @Autowired
    AccountService accountService;

    @GetMapping("/verify")
    public void checkViaEntity(@RequestParam int id, @RequestParam String password){
        System.out.println("Controller received: " + id+ "      " + password);

        accountService.checkViaAccount(new ViaEntity(id, password));
    }
}
