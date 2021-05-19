package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.Setter;
import lombok.experimental.SuperBuilder;

@SuperBuilder @Getter @Setter
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
