package dk.via.sep3.group1.applicationlogic;

import dk.via.sep3.group1.applicationlogic.networking.DataClient;
import dk.via.sep3.group1.applicationlogic.networking.DataClientImpl;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class ApplicationLogicApplication {

    public static void main(String[] args) {
        SpringApplication.run(ApplicationLogicApplication.class, args);

//        DataClientImpl client = new DataClientImpl();
//        client.start();
    }

}
