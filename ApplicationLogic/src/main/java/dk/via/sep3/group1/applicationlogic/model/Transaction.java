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
}
