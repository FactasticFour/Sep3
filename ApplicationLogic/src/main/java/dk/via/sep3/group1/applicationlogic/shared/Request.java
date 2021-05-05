package dk.via.sep3.group1.applicationlogic.shared;

import java.io.Serializable;

public class Request {
    private String type;
    private String argument; //TODO make enums

    public Request(String type, String argument)
    {
        this.type = type;
        this.argument = argument;
    }

    public String getType() {
        return type;
    }

    public String getArgument() {
        return argument;
    }
}
