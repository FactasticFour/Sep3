package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

import java.sql.Timestamp;

@AllArgsConstructor @Getter @Setter
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

}
