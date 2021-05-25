package dk.via.sep3.group1.applicationlogic.service.impl;

import dk.via.sep3.group1.applicationlogic.dao.AccountDAO;
import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.service.LoginService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class LoginServiceImpl implements LoginService {
   @Autowired
    AccountDAO accountDAO;


    @Override
    public Account validateAccount(String passwordHashed, String username) {
        Account account = accountDAO.getRoleByUsername(username);
        if (account != null && account.getApplicationPassword().equals(passwordHashed))
        {
            System.out.println("Password match");
            return account;
        }
        else
        {
            System.out.println("Passwords do not watch, default role object send to controller");
            return new Account();
        }
    }
}

