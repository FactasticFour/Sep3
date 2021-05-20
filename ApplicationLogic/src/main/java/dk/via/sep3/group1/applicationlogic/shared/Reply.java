package dk.via.sep3.group1.applicationlogic.shared;

public class Reply {
    public ReplyType type;
    public String payload;

    public Reply(ReplyType type, String payload) {
        this.type = type;
        this.payload = payload;
    }

    public ReplyType getType() {
        return type;
    }

    public void setType(ReplyType type) {
        this.type = type;
    }

    public String getPayload() {
        return payload;
    }

    public void setPayload(String payload) {
        this.payload = payload;
    }
}
