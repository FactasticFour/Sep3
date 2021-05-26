package dk.via.sep3.group1.applicationlogic.service.impl;

import dk.via.sep3.group1.applicationlogic.dao.FacilityDAO;
import dk.via.sep3.group1.applicationlogic.dao.MemberDAO;
import dk.via.sep3.group1.applicationlogic.dao.ViaEntityDAO;
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
    @Autowired
    ViaEntityDAO viaEntityDAO;
    @Autowired
    MemberDAO memberDAO;
    @Autowired
    FacilityDAO facilityDAO;

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
}
