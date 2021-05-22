package dk.via.sep3.group1.applicationlogic.model.dao;

import dk.via.sep3.group1.applicationlogic.model.ViaEntity;

public interface AccountDAO {
    ViaEntity getViaEntityWithId(int id);
}
