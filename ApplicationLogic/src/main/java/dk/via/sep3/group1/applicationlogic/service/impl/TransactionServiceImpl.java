package dk.via.sep3.group1.applicationlogic.service.impl;

import dk.via.sep3.group1.applicationlogic.dao.TransactionDAO;
import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.model.Transaction;
import dk.via.sep3.group1.applicationlogic.service.TransactionService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class TransactionServiceImpl implements TransactionService {
    @Autowired
    TransactionDAO transactionDAO;

    @Override
    public Transaction makeTransaction(Transaction transaction) {
        Account receiverAccount = transactionDAO.getAccountByVIAID(transaction.getReceiverAccountId().getViaEntity().getViaId());
        transaction.setReceiverAccountId(receiverAccount);
        System.out.println("Receiver account from DAO: " + receiverAccount);

        Account senderAccount = transactionDAO.getAccountByAccountID(transaction.getSenderAccountId().getAccountId());
        System.out.println("Sender account from DAO: " + senderAccount);

        // check if balance is OK here

        if (senderAccount.getBalance() >= transaction.getAmount()) {
            // Take money from sender's account
            System.out.println("money to remove" + transaction.getAmount());
            float senderAccountBalanceUpdated = senderAccount.getBalance() - transaction.getAmount();
            System.out.println("After money has been removed" + transaction.getAmount());
            senderAccount.setBalance(senderAccountBalanceUpdated);
            // update sender's account

            Account account = transactionDAO.updateAccountsBalance(senderAccount);
            System.out.println("Updated account returned from DAO: " + account);

            // Add money to receiver's account
            // update sender's account
        }
        transaction.setSenderAccountId(senderAccount);
        System.out.println(transaction.getSenderAccountId().getBalance());
        // return transactionDAO.makeTransfer(transaction);
        return transaction;
    }
}
