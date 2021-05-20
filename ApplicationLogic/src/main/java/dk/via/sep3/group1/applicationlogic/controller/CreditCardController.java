package dk.via.sep3.group1.applicationlogic.controller;

import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.model.CreditCard;
import dk.via.sep3.group1.applicationlogic.model.User;
import dk.via.sep3.group1.applicationlogic.service.CreditCardService;
import dk.via.sep3.group1.applicationlogic.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/creditcards")
public class CreditCardController {

    @Autowired
    CreditCardService creditCardService;

    @GetMapping("{creditCard}")
    public void addCreditCardToAccount(@PathVariable CreditCard creditCard){
        creditCardService.addCreditCardToAccount(creditCard);
    }

}