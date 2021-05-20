package dk.via.sep3.group1.applicationlogic.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

@AllArgsConstructor @Setter @Getter
public class Campus {
    @JsonProperty("city")
    public String city;
    @JsonProperty("street")
    public String street;
    @JsonProperty("postCode")
    public String postCode;
    @JsonProperty("name")
    public String name;

}
