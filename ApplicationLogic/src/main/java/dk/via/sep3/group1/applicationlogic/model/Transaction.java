package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;


import java.sql.Timestamp;

public class Transaction {
    @JsonProperty("receiverAccount")
    public Account receiverAccountId;
    @JsonProperty("senderAccount")
    public Account senderAccountId;
    @JsonProperty("payload")
    public int payload;
    @JsonProperty("comment")
    public String comment;
    @JsonProperty("type")
    public String type;
    @JsonProperty("timestamp")
    public Timestamp timestamp;

    public Transaction(Account receiverAccountId, Account senderAccountId, int payload, String comment, String type, Timestamp timestamp) {
        this.receiverAccountId = receiverAccountId;
        this.senderAccountId = senderAccountId;
        this.payload = payload;
        this.comment = comment;
        this.type = type;
        this.timestamp = timestamp;
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

    public int getPayload() {
        return payload;
    }

    public void setPayload(int payload) {
        this.payload = payload;
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
