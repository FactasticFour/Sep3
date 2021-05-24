package dk.via.sep3.group1.applicationlogic.model.dao;

import dk.via.sep3.group1.applicationlogic.model.Facility;
import dk.via.sep3.group1.applicationlogic.model.Member;
import dk.via.sep3.group1.applicationlogic.model.ViaEntity;

public interface AccountDAO {
    ViaEntity getViaEntityWithId(int id);

    Member getViaMemberById(int id);

    Facility getViaFacilityById(int id);
}
