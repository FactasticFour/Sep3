package dk.via.sep3.group1.applicationlogic.service.impl;

import dk.via.sep3.group1.applicationlogic.dao.TransactionDAO;
import dk.via.sep3.group1.applicationlogic.model.Account;
import dk.via.sep3.group1.applicationlogic.model.Transaction;
import dk.via.sep3.group1.applicationlogic.service.TransactionService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.sql.Date;
import java.sql.Timestamp;
import java.util.Calendar;
import java.util.GregorianCalendar;

@Service
public class TransactionServiceImpl implements TransactionService {
    @Autowired
    TransactionDAO transactionDAO;

    @Override
    public Transaction makeTransaction(Transaction transaction) {
        Account receiverAccount = transactionDAO.getAccountByVIAID(transaction.getReceiverAccountId().getViaEntity().getViaId());
        // TODO remove
        // transaction.setReceiverAccountId(receiverAccount);
        System.out.println("Receiver account from DAO: " + receiverAccount);

        Account senderAccount = transactionDAO.getAccountByAccountID(transaction.getSenderAccountId().getAccountId());
        System.out.println("Sender account from DAO: " + senderAccount);

        // check if balance is OK here

        if (senderAccount.getBalance() >= transaction.getAmount()) {
            // Take money from sender's account
            System.out.println("------> money to remove " + transaction.getAmount());
            float senderAccountBalanceUpdated = senderAccount.getBalance() - transaction.getAmount();

            System.out.println("------> Before money has been removed" + senderAccount.getBalance());
            senderAccount.setBalance(senderAccountBalanceUpdated);
            System.out.println("------> After money has been removed" + senderAccount.getBalance());
            // update sender's account

            Account account = transactionDAO.updateAccountsBalance(senderAccount);
            System.out.println(" ------> Updated account returned from DAO: " + account);

            // Add money to receiver's account
            // update sender's account
            float receiverAccountBalanceUpdated = receiverAccount.getBalance() + transaction.getAmount();
            receiverAccount.setBalance(receiverAccountBalanceUpdated);
            Account updateAccountsBalance = transactionDAO.updateAccountsBalance(receiverAccount);
            System.out.println(" ------> Updated receiver account: " + updateAccountsBalance);

            // register transaction
            Transaction transactionToSave = new Transaction();
            transactionToSave.setSenderAccountId(senderAccount);
            transactionToSave.setReceiverAccountId(receiverAccount);
            transactionToSave.setType(transaction.getType());
            transactionToSave.setAmount(transaction.getAmount());
            transactionToSave.setComment(transaction.getComment());

            Calendar calendar = Calendar.getInstance();
            transactionToSave.setTimestamp(new Timestamp(calendar.getTime().getTime()));
            //Transaction addTransaction = transactionDAO.addTransaction(transactionToSave);

            // return addTransaction;
        }


        return transaction;
    }
}
