package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;


public class Facility extends ViaEntity {
    @JsonProperty("name")
    public String name;
    @JsonProperty("campus")
    public Campus campus;
    @JsonProperty("account")
    public Account account;

    public Facility(int viaId, String password, String name, Campus campus, Account account) {
        super(viaId, password);
        this.name = name;
        this.campus = campus;
        this.account = account;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Campus getCampus() {
        return campus;
    }

    public void setCampus(Campus campus) {
        this.campus = campus;
    }

    public Account getAccount() {
        return account;
    }

    public void setAccount(Account account) {
        this.account = account;
    }
}
