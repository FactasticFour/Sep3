package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class User {
    @JsonProperty("userId")
    private int userId;
    @JsonProperty("userName")
    private String userName;
    @JsonProperty("password")
    private String password;


    public User() {
    }

    public int getUserId() {
        return userId;
    }

    public void setUserId(int userId) {
        this.userId = userId;
    }

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
