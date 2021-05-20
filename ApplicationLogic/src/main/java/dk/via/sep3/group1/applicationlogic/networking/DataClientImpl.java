package dk.via.sep3.group1.applicationlogic.networking;

import com.fasterxml.jackson.databind.ObjectMapper;
import dk.via.sep3.group1.applicationlogic.model.User;
import dk.via.sep3.group1.applicationlogic.shared.Request;
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

    public DataClientImpl() {
        try {
            socket = new Socket("127.0.0.1", 12345);
            inputStream = socket.getInputStream();
            outputStream = socket.getOutputStream();
            System.out.println("client has connected to server");

        } catch (IOException e) {
            e.printStackTrace();
        }
    }


    @Override
    public User getUser(int id) {
        User user = null;

        try {
            String payload = objectMapper.writeValueAsString(Integer.parseInt(String.valueOf(id)));
            Request request = new Request("getUserById", payload);

            byte[] valueAsBytesTest = objectMapper.writeValueAsBytes(request);
            outputStream.write(valueAsBytesTest);

            byte[] readAllBytes = inputStream.readAllBytes();
            String stringBytes = new String(readAllBytes);

            System.out.println(stringBytes);

            user = objectMapper.readValue(stringBytes, User.class);
        } catch (IOException e) {
            e.printStackTrace();
        }
        if (user != null) {
            return user;
        } else
            throw new RuntimeException("User is null");
    }

    @Override
    public void seedDatabase(){
        try {
            String payload = "";
            Request request = new Request("seedDatabase", payload);

            byte[] valueAsBytes = objectMapper.writeValueAsBytes(request);
            outputStream.write(valueAsBytes);

            System.out.println("sent seeding request to third tier");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
