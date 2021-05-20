package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

@Getter @Setter @AllArgsConstructor
public class Role {
    @JsonProperty("roleId")
    public int roleId;
    @JsonProperty("account")
    public Account account;
    @JsonProperty("roleType")
    public  String roleType;

}
