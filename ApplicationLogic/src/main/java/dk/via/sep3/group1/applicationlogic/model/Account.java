package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;


public class Account {

    @JsonProperty("accountId")
    public int accountId;
    @JsonProperty("applicationPassword")
    public String applicationPassword;
    @JsonProperty("balance")
    public int balance = 0;

    public Account(int accountId, String applicationPassword, int balance) {
        this.accountId = accountId;
        this.applicationPassword = applicationPassword;
        this.balance = balance;
    }

    public int getAccountId() {
        return accountId;
    }

    public void setAccountId(int accountId) {
        this.accountId = accountId;
    }

    public String getApplicationPassword() {
        return applicationPassword;
    }

    public void setApplicationPassword(String applicationPassword) {
        this.applicationPassword = applicationPassword;
    }

    public int getBalance() {
        return balance;
    }

    public void setBalance(int balance) {
        this.balance = balance;
    }
}
