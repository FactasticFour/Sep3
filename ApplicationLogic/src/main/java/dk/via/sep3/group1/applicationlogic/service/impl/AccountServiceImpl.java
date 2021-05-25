package dk.via.sep3.group1.applicationlogic.service.impl;

import dk.via.sep3.group1.applicationlogic.model.Facility;
import dk.via.sep3.group1.applicationlogic.model.Member;
import dk.via.sep3.group1.applicationlogic.model.ViaEntity;
import dk.via.sep3.group1.applicationlogic.dao.AccountDAO;
import dk.via.sep3.group1.applicationlogic.service.AccountService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class AccountServiceImpl implements AccountService {

    @Autowired
    AccountDAO accountDAO;

    @Override
    public ViaEntity checkViaAccount(ViaEntity entityToCheck) {

        Member viaMember = accountDAO.getViaMemberById(entityToCheck.getViaId());
        if (viaMember != null){
            System.out.println("account service returning member");
            return viaMember;
        } else {
            Facility viaFacility = accountDAO.getViaFacilityById(entityToCheck.getViaId());
            System.out.println("account service returning facility");
            return viaFacility;
        }
    }
}
