package dk.via.sep3.group1.applicationlogic.controller;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.model.CreditCard;
import dk.via.sep3.group1.applicationlogic.service.CreditCardService;
import dk.via.sep3.group1.applicationlogic.shared.Serialization;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/creditcard")
public class CreditCardController {

    @Autowired
    CreditCardService creditCardService;
    ObjectMapper objectMapper = new ObjectMapper();

    @GetMapping("addcredit/{creditCard}")
    public boolean addCreditCardToAccount(@PathVariable String creditCard) {
        CreditCard deserialized = null;
        try {
            System.out.println(creditCard.toString());
            deserialized = objectMapper.readValue(creditCard, CreditCard.class);
        } catch (JsonProcessingException e) {
            e.printStackTrace();
        }
        return creditCardService.addCreditCardToAccount(deserialized);
    }

    @GetMapping("checkcreditcard/{id}")
    public boolean checkCreditCard(@PathVariable int id)
    {
        boolean response = creditCardService.checkCreditCard(id);
        System.out.println("response got to controller : " + response);
        return response;
    }

    @PatchMapping("depositmoney")
    public boolean depositMoney(@RequestBody String Json)
    {
        Account account = null;
        try {
            account = objectMapper.readValue(Json, Account.class);
        } catch (JsonProcessingException e) {
            e.printStackTrace();
        }
        return creditCardService.depositMoney(account);
    }

}