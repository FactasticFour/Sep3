package dk.via.sep3.group1.applicationlogic.networking;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import dk.via.sep3.group1.applicationlogic.model.CreditCard;
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
        User user;

        String payload = serialize(id);
        Request request = new Request("getUserById", payload);
        writeBytes(request);

        String  readString = readBytes();
        user = deserialize(readString, User.class);
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
    @Override
    public void addCreditCardToAccount(CreditCard creditCard) {
        try {
            System.out.println("a");
            String payload = objectMapper.writeValueAsString(creditCard);
            System.out.println("b");
            Request request = new Request("ADD_CREDIT_CARD_TO_ACCOUNT", payload);
            System.out.println(request.getType() + "\n" + request.getArgument().toString());
            byte[] valueAsBytes = objectMapper.writeValueAsBytes(request);
            System.out.println("d");
            outputStream.write(valueAsBytes);
            System.out.println("e");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
    public <T> String serialize(T objectToSerialize){
        String serializedString = "";
        try {
            serializedString = objectMapper.writeValueAsString(objectToSerialize);
        } catch (JsonProcessingException e) {
            e.printStackTrace();
        }
        return serializedString;
    }


    public <T> T deserialize(String objectToDeserialize, Class<T> tClass){
        T object = null;
        try {

            object = objectMapper.readValue(objectToDeserialize, tClass);
        } catch (JsonProcessingException e) {
            e.printStackTrace();
        }
        return object;
    }

    public String readBytes() {
        byte[] readAllBytes = new byte[1024];
        try {
            readAllBytes = inputStream.readAllBytes();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return new String(readAllBytes);
    }


    public void writeBytes(Object objectToSend) {
        byte[] valueAsBytesTest;
        System.out.println(objectToSend);
        try {
            valueAsBytesTest = objectMapper.writeValueAsBytes(objectToSend);
            outputStream.write(valueAsBytesTest);

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
