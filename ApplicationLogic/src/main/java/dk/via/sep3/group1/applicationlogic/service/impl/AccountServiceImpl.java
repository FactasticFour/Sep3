package dk.via.sep3.group1.applicationlogic.service.impl;

import dk.via.sep3.group1.applicationlogic.dao.*;
import dk.via.sep3.group1.applicationlogic.model.*;
import dk.via.sep3.group1.applicationlogic.service.AccountService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class AccountServiceImpl implements AccountService {

    @Autowired
    AccountDAO accountDAO;
    @Autowired
    ViaEntityDAO viaEntityDAO;
    @Autowired
    MemberDAO memberDAO;
    @Autowired
    FacilityDAO facilityDAO;
    @Autowired
    RoleDAO roleDAO;

    @Override
    public ViaEntity checkViaAccount(ViaEntity entityToCheck) {

        ViaEntity viaEntity = viaEntityDAO.getViaEntityWithId(entityToCheck.getViaId());
        System.out.println(viaEntity);

        if (viaEntity.getPassword().equals(entityToCheck.getPassword())){
            //get member or facility

            Member dbMember = memberDAO.getMemberWithId(entityToCheck.getViaId());
            if (dbMember != null){
                return dbMember;
            } else {
                Facility dbFacility = facilityDAO.getFacilityWithId(entityToCheck.getViaId());
                if (dbFacility != null){
                    return dbFacility;
                } else {
                    return null;
                }
            }
        }
        return null;
    }

    @Override
    public Account createAccount(Account accountToCreate) {

        System.out.println("*** service ***");
        //check if via id already has an account
        if(!accountDAO.checkAccountWithViaId(accountToCreate.getViaEntity().getViaId())){
            System.out.println("*** setting balance and role and sending account");
            // balance = 0
            accountToCreate.setBalance(0);
            // add correct role id
            Role roleWithId = roleDAO.getRoleWithType(accountToCreate.getAccountType().getRoleType());
            accountToCreate.setAccountType(roleWithId);

            accountDAO.addAccount(accountToCreate);
        }


        return null;
    }
}
