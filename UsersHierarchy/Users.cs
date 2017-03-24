using System;

namespace UsersHierarchy
{
    public class User
    {
        //FIELDS
        public string username;
        
        //PROPERTIES
        public virtual string role
        {
            get { return "guest"; }
        }

        /// <summary> Constructor of User object, User(username)
        /// </summary>
        /// <param name="username"></param>
        public User(string username)
        {
            this.username = username;
        }

        /// <summary> Verifies if input credentials match
        /// </summary>
        /// <returns>true, if input credentials match </returns>
        public virtual bool CredentialsFromConsoleAreVerified()                     // Is there any way to force overriding by derived classes without making it abstract ?
        {
            WriteUserInfoToConsole();
            Console.WriteLine("No verification needed\n");   
            return true;
        }

        public virtual void WriteUserInfoToConsole()
        {
            Console.WriteLine("\nUser: {0}\nRole: {1}", this.username, this.role);
        }

        protected virtual string GetPassword()
        {
            Console.Write("Enter password : ");
            return Console.ReadLine();
        }
    }

    /// <summary>
    /// Editor class extends User class
    /// </summary>
    public class Editor : User
    {
        //FIELDS
        private string password;

        //PROPERTIES
        public override string role
        {
            get { return "editor"; }
        }

        public Editor(string username, string password) : base(username)
        {
            this.password = password;
        }

        public override bool CredentialsFromConsoleAreVerified()                     
        {
            string enteredPassword = GetPassword();
            if(this.password == enteredPassword)
            {
                return true;
            }
            else
            {
                Console.WriteLine("wrong password");
                return false;
            }
            
        }
    }

    public class Admin : User
    {
        //FIELDS
        private string password;
        private string key;

        //PROPERTIES
        public override string role
        {
            get { return "admin"; }
        }

        public Admin(string username, string password, string key) : base(username)
        {
            this.password = password;
            this.key = key;
        }

        public override bool CredentialsFromConsoleAreVerified()
        {
            string enteredPassword = GetPassword();
            Console.Write("Enter administrator key: ");
            string enteredKey = Console.ReadLine();
            if (this.password == enteredPassword && this.key == enteredKey)
            {
                return true;
            }
            else
            {
                Console.WriteLine("wrong password or key\n");
                return false;
            }

        }
    }
}
