package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;
import lombok.experimental.SuperBuilder;

@Getter @Setter @SuperBuilder
public class ViaEntity {
    @JsonProperty("viaId")
    public int viaId;
    @JsonProperty("password")
    public String password;

}
