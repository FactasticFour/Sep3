package dk.via.sep3.group1.applicationlogic.shared;

import java.io.Serializable;

public class Request {
    private String type; //TODO make enums
    private String payload;




    public Request(String type, String payload)
    {
        this.type = type;
        this.payload = payload;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public String getPayload() {
        return payload;
    }

    public void setPayload(String payload) {
        this.payload = payload;
    }
}
