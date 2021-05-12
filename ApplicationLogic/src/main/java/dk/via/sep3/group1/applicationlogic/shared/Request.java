package dk.via.sep3.group1.applicationlogic.shared;

import java.io.Serializable;

public class Request {
    private String type; //TODO make enums
    private Object argument;

    public Request(String type, String argument)
    {
        this.type = type;
        this.argument = argument;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public Object getArgument() {
        return argument;
    }

    public void setArgument(Object argument) {
        this.argument = argument;
    }
}
