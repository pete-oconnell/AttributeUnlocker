using System;
using ArchestrA.GRAccess;

namespace UnlockAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            string nodeName = Environment.MachineName;
            string galaxyName = args[0];
            string template = args[1];
            string attribute = args[2];
            string username = "";
            string password = "";
            if (args.Length >= 4)
            {
                username = args[3];
                
            }

            if (args.Length >= 5)
            {
                password = args[4];
            }
            

            GRAccessApp grAccess = new GRAccessAppClass();

            IGalaxies gals = grAccess.QueryGalaxies(nodeName);
            if (gals == null || grAccess.CommandResult.Successful == false)
            {
                Console.WriteLine(grAccess.CommandResult.CustomMessage + grAccess.CommandResult.Text);
                return;
            }
            IGalaxy galaxy = gals[galaxyName];

            ICommandResult cmd;
            if (galaxy == null)
            {
                Console.WriteLine("Galaxy '" + galaxyName + "' does not exist");
                Console.WriteLine("Press return key to exit.");
                Console.ReadLine();
                return;
            }

            galaxy.Login(username, password);
            cmd = galaxy.CommandResult;
            if (!cmd.Successful)
            {
                Console.WriteLine("Login to galaxy Example1 Failed :" +
                                cmd.Text + " : " +
                                cmd.CustomMessage);
                return;
            }

            string[] tagnames = { template };

            IgObjects queryResult = galaxy.QueryObjectsByName(
            EgObjectIsTemplateOrInstance.gObjectIsTemplate,
            ref tagnames);

            ITemplate myTemplate = (ITemplate)queryResult[1];
            myTemplate.CheckOut();
            IAttributes myAttributes = myTemplate.Attributes;

            IAttribute myAttribute = myAttributes[attribute];

            myAttribute.SetLocked(MxPropertyLockedEnum.MxUnLocked);

            myTemplate.Save();
            myTemplate.CheckIn();

            galaxy.Logout();

            Console.WriteLine("The attribute should have been unlocked");
            Console.WriteLine("Press return to exit");
            Console.ReadLine();




		
        }
    }
}
