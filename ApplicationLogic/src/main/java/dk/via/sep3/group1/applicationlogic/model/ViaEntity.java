package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;

public class ViaEntity {
    @JsonProperty("viaId")
    public int viaId;
    @JsonProperty("password")
    public String password;
    @JsonProperty("account")
    public Account account;

    public ViaEntity() {
    }

    public ViaEntity(int viaId, String password) {
        this.viaId = viaId;
        this.password = password;
    }

    public ViaEntity(int viaId, String password, Account account) {
        this.viaId = viaId;
        this.password = password;
        this.account = account;
    }

    public int getViaId() {
        return viaId;
    }

    public void setViaId(int viaId) {
        this.viaId = viaId;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public Account getAccount() {
        return account;
    }

    public void setAccount(Account account) {
        this.account = account;
    }
}
