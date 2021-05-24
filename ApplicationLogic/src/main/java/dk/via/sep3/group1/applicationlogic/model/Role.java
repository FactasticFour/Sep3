package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;


public class Role {
    @JsonProperty("roleId")
    public int roleId;
    @JsonProperty("account")
    public Account account;
    @JsonProperty("roleType")
    public  String roleType;

    public Role() {
    }

    public Role(int roleId, Account account, String roleType) {
        this.roleId = roleId;
        this.account = account;
        this.roleType = roleType;
    }

    public int getRoleId() {
        return roleId;
    }

    public void setRoleId(int roleId) {
        this.roleId = roleId;
    }

    public Account getAccount() {
        return account;
    }

    public void setAccount(Account account) {
        this.account = account;
    }

    public String getRoleType() {
        return roleType;
    }

    public void setRoleType(String roleType) {
        this.roleType = roleType;
    }

    @Override
    public String toString() {
        return "Role{" +
                "roleId=" + roleId +
                ", account=" + account +
                ", roleType='" + roleType + '\'' +
                '}';
    }
}
