# Test Project for innoloft by Ishrar G

### This project includes API with Methods as below
- GetUserEvents(UserID) : GET Method - Accepts UserID and returns all the Events (directly from database) so user can display or use the objects to update events
- GetEvent(EventID)  : GET Method :  Accepts EventID and returns Event Object directly from database.
- GetEventDetails (EventID) : GET Method - This Method returns Event and Organizer details for the specified eventId. This method will be used on Event Info page 
- SaveEvent - POST Method - This method accepts Json object of Event 
- RemoveEvent
- 

Database is SQLite. No need to do any setup. It creates database if missing. It also insert two records in Event and user table.

Unit Test file is also included in the same project.
