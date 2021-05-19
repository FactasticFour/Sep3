package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Getter;
import lombok.Setter;
import lombok.experimental.SuperBuilder;

@SuperBuilder @Getter @Setter
public class Facility extends ViaEntity {
    @JsonProperty("name")
    public String name;
    @JsonProperty("campus")
    public Campus campus;
    @JsonProperty("account")
    public Account account;

}