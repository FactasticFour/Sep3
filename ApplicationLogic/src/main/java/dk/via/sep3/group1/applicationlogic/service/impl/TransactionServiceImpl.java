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
        System.out.println("working so far");
        Account senderAccount = transactionDAO.getAccountByAccountID(transaction.getSenderAccountId().getAccountId());
        // check if balance is OK here
        transaction.setSenderAccountId(senderAccount);
        System.out.println(transaction.getSenderAccountId().getBalance());
       // return transactionDAO.makeTransfer(transaction);



        return transaction;
    }
}
