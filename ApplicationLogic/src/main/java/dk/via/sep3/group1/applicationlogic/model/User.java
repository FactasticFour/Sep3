package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class User {
    @JsonProperty("userId")
    private int userId;
    @JsonProperty("userName")
    private String userName;
    @JsonProperty("password")
    private String password;
}
