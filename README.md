# Homework2-UsersHierarchy
Creates hierarchy of classes for Users of a program. 
There can be different kind of users,particularly, Admins, Editors and Guests.
User is able to authorize by entering Username and Password (in general), but in particulartype, authorization requirement is different. 
For example: To authorize as admin, user should input username, password and additional administrative secret key.  
Editor should login by username and password only
Guest can login by only a User Name.

Another module, called Authorizator should accept/reject authorization and record all the authorization actions (When, who and which kind of user).
After authorization “Accepted”, the simple “Command Line” should be prompted which support only two commands
1.Print {MESSAGE} (prints input message to console)
2.Exit (user log out)User is able to perform infinite print commands, 
until no EXIT es entered. 
Command execution module should be modeled as  a separate module.
Whole process should be done in an infinite loop.  
After every exit, user should be able to login again using on of available user types.

Requirements1. No one of User hierarchy classes should “see” Authorization module.
2.Authorization module should ONLY know about User class from the hierarchy (i.e. Editorand Admin classes should not be accessed from Authorization module)
