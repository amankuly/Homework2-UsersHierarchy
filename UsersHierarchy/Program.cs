/* Hope you will enjoy the Command Prompt :)
 * Defined user are:
 *      admin/admin/key
 *      editor/editor
 * 
 * You can also login with any other username as guest 
 * 
 * SUPPORTED COMMANDS:
 *      PRINT:  prints everything you type
 *      EXIT:   logout
 *      
 * System will also report all access attempts after logout // No logic, just in case :)
 * 
 * 
 * Developer annmankulyan@gmail.com
 * 
 * */


using System;


namespace UsersHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            SystemUnit system_unit = new SystemUnit();
            system_unit.RunSession();
        }
    }
}
