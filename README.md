# Via Pay

### Group 1:
- Maria Asenova
- Ionut Grosu
- Claudiu Hornet
- Cezary Korenczuk 

This is the repository containing all three tiers of our SEP3 implementation


## Startup order

1. PersistenceLayer (C#)
2. ApplicationLogic (Java)
3. PresentationLayer (C#)


## Database seeding

Prerequisites: 
* Start PersistenceLayer
* Start ApplicationLogic

Send a HTTP GET request to http://localhost:8080/seeddatabase

This will empty the tables and input new data ready for testing purposes
