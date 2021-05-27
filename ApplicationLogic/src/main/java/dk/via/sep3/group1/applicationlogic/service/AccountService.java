package dk.via.sep3.group1.applicationlogic.service;

import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.model.ViaEntity;

public interface AccountService {
    ViaEntity checkViaAccount(ViaEntity entityToCheck);

    Account createAccount(Account accountToCreate);
}
