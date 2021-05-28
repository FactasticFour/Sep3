package dk.via.sep3.group1.applicationlogic.shared;

import com.fasterxml.jackson.annotation.JsonProperty;

public class Reply {
    public final String SEND_USER = "SEND_USER";
    public final String BAD_REQUEST = "BAD_REQUEST";
    public final String SEEDING_SUCCESS = "SEEDING_SUCCESS";
    public final String VERIFY_CREDIT_CARD_TO_ACCOUNT = "VERIFY_CREDIT_CARD_TO_ACCOUNT";
    public final String CHECK_CREDIT_CARD_REPLY = "CHECK_CREDIT_CARD_REPLY";
    public final String DEPOSIT_MONEY_REPLY = "DEPOSIT_MONEY_REPLY";
    @JsonProperty("type")
    private String type;
    @JsonProperty("payload")
    private String payload;

    public Reply() {
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public Reply(String type, String payload) {
        this.type = type;
        this.payload = payload;
    }

    public String getPayload() {
        return payload;
    }

    public void setPayload(String payload) {
        this.payload = payload;
    }
}
