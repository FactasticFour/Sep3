package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class Role {
    @JsonProperty("roleId")
    public int roleId;
    @JsonProperty("account")
    public Account account;
    @JsonProperty("roleType")
    public  String roleType;

}
