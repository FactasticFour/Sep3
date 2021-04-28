package dk.via.sep3.group1.applicationlogic.model;

public class User {
    private int id;
    private String userName;
    private String password;

    public User() {
    }

    public User(int id, String name,String password) {
        this.id = id;
        this.userName = name;
        this.password = password;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return userName;
    }

    public void setName(String name) {
        this.userName = name;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
