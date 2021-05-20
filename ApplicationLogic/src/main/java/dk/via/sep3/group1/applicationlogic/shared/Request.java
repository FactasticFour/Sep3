package dk.via.sep3.group1.applicationlogic.shared;

import java.io.Serializable;

public class Request {
    private RequestType type;
    private String payload;


    public RequestType getType() {
        return type;
    }

    public void setType(RequestType type) {
        this.type = type;
    }

    public Request(RequestType type, String payload) {
        this.type = type;
        this.payload = payload;
    }

    public String getPayload() {
        return payload;
    }

    public void setPayload(String payload) {
        this.payload = payload;
    }
}
