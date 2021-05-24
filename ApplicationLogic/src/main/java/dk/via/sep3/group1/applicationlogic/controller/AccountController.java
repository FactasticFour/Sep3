package dk.via.sep3.group1.applicationlogic.controller;

import dk.via.sep3.group1.applicationlogic.model.Role;
import dk.via.sep3.group1.applicationlogic.model.ViaEntity;
import dk.via.sep3.group1.applicationlogic.service.AccountService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/account")
public class AccountController {

    @Autowired
    AccountService accountService;

    @GetMapping
    public ViaEntity checkViaEntity(@RequestParam int id, @RequestParam String password){
        System.out.println("Controller received: " + id+ "      " + password);

        return accountService.checkViaAccount(new ViaEntity(id, password));
    }

    @PostMapping
    public void createAccount(@RequestBody Role role){
        System.out.println(role);

    }
}
