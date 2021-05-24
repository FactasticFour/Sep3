package dk.via.sep3.group1.applicationlogic.networking;

import dk.via.sep3.group1.applicationlogic.model.Facility;
import dk.via.sep3.group1.applicationlogic.model.Member;
import dk.via.sep3.group1.applicationlogic.model.User;
import dk.via.sep3.group1.applicationlogic.model.ViaEntity;

public interface DataClient {

    void seedDatabase();

    User getUser(int id);

    ViaEntity getViaEntityById(int id);

    Member getViaMemberById(int id);

    Facility getViaFacilityById(int id);
}
