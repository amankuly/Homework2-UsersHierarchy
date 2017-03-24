using System;


namespace UsersHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            Authorizator authorizator_instance = new Authorizator();
            authorizator_instance.listOfAllUsers.Add( new User("guest"));
            authorizator_instance.listOfAllUsers.Add( new Editor("editor", "editor"));
            authorizator_instance.listOfAllUsers.Add( new Admin("admin", "admin", "key"));

            authorizator_instance.OutputAccessAttemptsList();

            Console.WriteLine(authorizator_instance.getUserByName("admin").role);
            //guestuser.VerifyCredentialsFromConsole();

            //Editor editoruser = new Editor("editor", "editor");
            //editoruser.VerifyCredentialsFromConsole();

            //Admin adminuser = new Admin("admin", "admin", "key");
            //adminuser.VerifyCredentialsFromConsole();

            Console.ReadLine();


            
        }
    }
}
