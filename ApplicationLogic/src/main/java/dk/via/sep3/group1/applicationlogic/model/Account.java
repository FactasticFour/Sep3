package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class Account {

    @JsonProperty("accountId")
    public int accountId;
    @JsonProperty("applicationPassword")
    public String applicationPassword;
    @JsonProperty("balance")
    public int balance = 0;
    @JsonProperty("viaEntity")
    public ViaEntity viaEntity;

    public Account() {
    }
}
