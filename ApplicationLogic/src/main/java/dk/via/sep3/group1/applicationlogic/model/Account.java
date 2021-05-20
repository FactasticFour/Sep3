package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

@AllArgsConstructor @Getter @Setter
public class Account {

    @JsonProperty("accountId")
    public int accountId;
    @JsonProperty("applicationPassword")
    public String applicationPassword;
    @JsonProperty("balance")
    public int balance = 0;

}
