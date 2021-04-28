package dk.via.sep3.group1.applicationlogic.networking;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import dk.via.sep3.group1.applicationlogic.model.User;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;

@Service
public class DataClientImpl implements DataClient {
    private Socket socket;
    private OutputStream outputStream;
    private InputStream inputStream;
    private ObjectMapper objectMapper = new ObjectMapper();

    public void start() {
        try {
            socket = new Socket("127.0.0.1", 12345);
            outputStream = socket.getOutputStream();
            inputStream = socket.getInputStream();

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public User getUser(int id) {
        User user = null;

        try {
            byte[] valueAsBytes = objectMapper.writeValueAsBytes(Integer.parseInt(String.valueOf(id)));
            outputStream.write(valueAsBytes);
            byte[] readAllBytes = inputStream.readAllBytes();
            user = objectMapper.readValue(readAllBytes, User.class);
        } catch (IOException e) {
            e.printStackTrace();
        }
        if (user != null) {
            return user;
        } else
            throw new RuntimeException("User is null");
    }
}
