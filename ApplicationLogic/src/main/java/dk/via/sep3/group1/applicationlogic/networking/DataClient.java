package dk.via.sep3.group1.applicationlogic.networking;

import dk.via.sep3.group1.applicationlogic.model.User;

public interface DataClient {
    void seedDatabase();
    User getUser(int id);
}
