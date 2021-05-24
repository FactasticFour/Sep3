package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.sql.Timestamp;

public class Transaction {
    @JsonProperty("receiverAccount")
    public Account receiverAccountId;
    @JsonProperty("senderAccount")
    public Account senderAccountId;
    @JsonProperty("amount")
    public float amount;
    @JsonProperty("comment")
    public String comment;
    @JsonProperty("type")
    public String type;
    @JsonProperty("timestamp")
    public Timestamp timestamp;

    public Transaction() {
    }

    public Account getReceiverAccountId() {
        return receiverAccountId;
    }

    public void setReceiverAccountId(Account receiverAccountId) {
        this.receiverAccountId = receiverAccountId;
    }

    public Account getSenderAccountId() {
        return senderAccountId;
    }

    public void setSenderAccountId(Account senderAccountId) {
        this.senderAccountId = senderAccountId;
    }

    public float getAmount() {
        return amount;
    }

    public void setAmount(float amount) {
        this.amount = amount;
    }

    public String getComment() {
        return comment;
    }

    public void setComment(String comment) {
        this.comment = comment;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public Timestamp getTimestamp() {
        return timestamp;
    }

    public void setTimestamp(Timestamp timestamp) {
        this.timestamp = timestamp;
    }
}
