package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class Member extends ViaEntity{
    @JsonProperty("firstName")
    public String firstName;
    @JsonProperty("lastName")
    public String lastName;
    @JsonProperty("cpr")
    public long cpr;
    @JsonProperty("account")
    public Account account;


}
