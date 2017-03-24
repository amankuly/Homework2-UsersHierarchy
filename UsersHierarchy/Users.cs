/* HERE ARE DEFINED 3 TYPES OF USERS: User, Editor, Admin
 * 
 * CLASS User: is similar to guest user meaning, password verificaion is not necessary
 * CLASS Editor: needs password to be verified
 * CLASS Admin: needs passoword and additional administrative key to be verified
 * 
 * 
 * Developer - annmankulyan@gmail.com
 * 
 * */


using System;

namespace UsersHierarchy
{
    // _DEFINING CLASS USER_
    public class User
    {
        // _FIELDS_

        /// <summary>
        /// Stores username
        /// </summary>
        /// 
        public string username;
        




        // _PROPERTIES_

        /// <summary>
        /// Keeps the role of user, for now it's readonly
        /// </summary>
        /// 
        public virtual string role
        {
            get { return "guest"; }
        }





        // _CONSTRUCTOR_

        public User(string username)
        {
            this.username = username;
        }





        // _METHODS_

        /// <summary> 
        /// Verifies if input credentials match
        /// </summary>
        /// <returns>true, if input credentials match </returns>
        /// 
        public virtual bool CredentialsFromConsoleAreVerified()                     // Is there any way to force overriding by derived classes without making it abstract ?
        {
            WriteUserInfoToConsole();
            Console.WriteLine("No verification needed\n");   
            return true;
        }



        /// <summary>
        /// Simple funcion to output user basic info to consol in User: {0}\nRole: {1} format
        /// </summary>
        /// 
        public virtual void WriteUserInfoToConsole()
        {
            Console.WriteLine("\nUser: {0}\nRole: {1}", this.username, this.role);
        }



        /// <summary>
        /// getting password
        /// </summary>
        /// <returns></returns>
        /// 
        protected virtual string GetPassword()
        {
            Console.Write("Enter password : ");
            return Console.ReadLine();
        }
    }







    // _DEFINING CLASS EDITOR_
    /// <summary>
    /// Editor class extends User class
    /// </summary>
    /// 
    public class Editor : User
    {
        // _FIELDS_

        /// <summary>
        /// Stores password
        /// </summary>
        /// 
        private string password;




        // _PROPERTIES_

        /// <summary>
        /// Overrides the Role
        /// </summary>
        /// 
        public override string role
        {
            get { return "editor"; }
        }




        // _CONSTRUCTOR_

        public Editor(string username, string password) : base(username)
        {
            this.password = password;
        }




        // _METHODS_

        /// <summary>
        /// Verify editor's credentials entered from console
        /// </summary>
        /// <returns></returns>
        /// 
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



    // _DEFINIG CLASS ADMIN_

    /// <summary>
    /// Admin class extends User
    /// </summary>
    /// 
    public class Admin : User
    {
        // _FIELDS_

        /// <summary>
        /// Keeps password and key for admin user
        /// </summary>
        /// 
        private string password;
        private string key;




        // _PROPERTIES_

        /// <summary>
        /// Overrides the Role 
        /// </summary>
        /// 
        public override string role
        {
            get { return "admin"; }
        }




        // _CONSTRUCTOR_

        public Admin(string username, string password, string key) : base(username)
        {
            this.password = password;
            this.key = key;
        }




        // _METHODS_

        /// <summary>
        /// Verify admin's credentials entered from console
        /// </summary>
        /// <returns></returns>
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
