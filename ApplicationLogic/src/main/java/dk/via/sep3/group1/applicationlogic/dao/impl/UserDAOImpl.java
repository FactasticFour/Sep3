package dk.via.sep3.group1.applicationlogic.dao.impl;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import dk.via.sep3.group1.applicationlogic.model.User;
import dk.via.sep3.group1.applicationlogic.dao.UserDAO;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import dk.via.sep3.group1.applicationlogic.networking.DataClientImpl;
import dk.via.sep3.group1.applicationlogic.shared.Reply;
import dk.via.sep3.group1.applicationlogic.shared.Request;
import dk.via.sep3.group1.applicationlogic.shared.Serialization;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class UserDAOImpl implements UserDAO {
private ObjectMapper objectMapper;

@Autowired
DataClientImpl dataClient;

    public UserDAOImpl() {
    }

    @Override
    public User getUserById(int id) {
        Request request = new Request();
        request.setPayload(Serialization.serialize(id));
        request.setType(request.GET_USER_BY_ID);
        Reply reply = dataClient.handleRequest(request);
        if(reply.getType().equals(reply.SEND_USER)){
            User user = Serialization.deserialize(reply.getPayload(), User.class);
            return user;
        }
        else {
         throw new NullPointerException(reply.BAD_REQUEST);
        }
    }


}
