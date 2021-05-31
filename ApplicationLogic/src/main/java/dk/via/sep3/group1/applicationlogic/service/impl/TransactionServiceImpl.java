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
        System.out.println(receiverAccount.getApplicationPassword());
        Account senderAccount = null;




        return transaction;
    }
}
