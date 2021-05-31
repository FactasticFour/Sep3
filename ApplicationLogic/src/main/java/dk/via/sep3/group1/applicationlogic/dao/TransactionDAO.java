package dk.via.sep3.group1.applicationlogic.dao;

import dk.via.sep3.group1.applicationlogic.model.Account;

public interface TransactionDAO {
    Account getAccountByVIAID(int viaid);
    Account getAccountByAccountID(int accountID);
    Account updateAccountsBalance(Account account);
}
