package dk.via.sep3.group1.applicationlogic.controller;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import dk.via.sep3.group1.applicationlogic.model.CreditCard;
import dk.via.sep3.group1.applicationlogic.service.CreditCardService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.net.http.HttpResponse;

@RestController
@RequestMapping("/creditcards")
public class CreditCardController {

    @Autowired
    CreditCardService creditCardService;
    ObjectMapper objectMapper = new ObjectMapper();

    @PostMapping(path = "/addcreditcard", consumes = "application/json", produces = "application/json")
    public ResponseEntity addCreditCardToAccount(@RequestBody String creditcard) {
        System.out.println(creditcard);
        CreditCard deserialized = null;
        try {
            deserialized = objectMapper.readValue(creditcard, CreditCard.class);
            creditCardService.addCreditCardToAccount(deserialized);
            return new ResponseEntity(HttpStatus.OK);
        } catch (JsonProcessingException | IllegalAccessException e) {
            return new ResponseEntity(e.getMessage(), HttpStatus.NOT_ACCEPTABLE);
        }
    }
}