package dk.via.sep3.group1.applicationlogic.service.impl;

import dk.via.sep3.group1.applicationlogic.model.ViaEntity;
import dk.via.sep3.group1.applicationlogic.model.dao.AccountDAO;
import dk.via.sep3.group1.applicationlogic.service.AccountService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class AccountServiceImpl implements AccountService {

    @Autowired
    AccountDAO accountDAO;

    @Override
    public ViaEntity checkViaAccount(ViaEntity entityToCheck) {
        ViaEntity dbViaEntity = accountDAO.getViaEntityWithId(entityToCheck.viaId);

        if (dbViaEntity.getPassword().equals(entityToCheck.getPassword())){
            return dbViaEntity;
        }

        return null;
    }
}
