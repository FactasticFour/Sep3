package dk.via.sep3.group1.applicationlogic.controller;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
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
    private ObjectMapper objectMapper = new ObjectMapper();

    @GetMapping("{creditCard1}")
    public void addCreditCardToAccount(@PathVariable String creditCard1){
        try {
            System.out.println(creditCard1);
           CreditCard deserialized = objectMapper.readValue(creditCard1, CreditCard.class);
            System.out.println(deserialized);
            creditCardService.addCreditCardToAccount(deserialized);
            System.out.println(deserialized.getCreditCardNumber());
        } catch (JsonProcessingException e) {
            e.printStackTrace();
        }

    }

}