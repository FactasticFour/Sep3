package dk.via.sep3.group1.applicationlogic;

import dk.via.sep3.group1.applicationlogic.model.CreditCard;
import dk.via.sep3.group1.applicationlogic.model.Member;
import dk.via.sep3.group1.applicationlogic.model.ViaEntity;
import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import dk.via.sep3.group1.applicationlogic.networking.DataClientImpl;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class ApplicationLogicApplication {

    public static void main(String[] args) {
        SpringApplication.run(ApplicationLogicApplication.class, args);

//        DataClientImpl dataClient = new DataClientImpl();
//        ViaEntity viaEntity = ViaEntity.builder().viaId(123456).password("1234567899").build();
//        dataClient.serialize(viaEntity);
//        System.out.println(dataClient.serialize(viaEntity));
//        ViaEntity deserialized = dataClient.deserialize(dataClient.serialize(viaEntity), ViaEntity.class);
//        System.out.println(deserialized.password);
    }

}
