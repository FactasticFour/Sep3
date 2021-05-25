package dk.via.sep3.group1.applicationlogic.shared;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.io.Serializable;

public class Request {
    public final String GET_USER_BY_ID = "GET_USER_BY_ID";
    public final String SEED_DATABASE = "SEED_DATABASE";
    public final String GET_ACCOUNT_BY_USERNAME = "GET_ACCOUNT_BY_USERNAME";
    @JsonProperty("type")
    private String type;
    @JsonProperty("payload")
    private String payload;

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public Request(String type, String payload) {
        this.type = type;
        this.payload = payload;
    }

    public String getPayload() {
        return payload;
    }

    public void setPayload(String payload) {
        this.payload = payload;
    }

    public Request() {
    }
}
