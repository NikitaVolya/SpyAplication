
using SpyCommunicationLib;
using SpyCommunicationLib.Directors;

namespace Tester
{
 

    internal class Program
    {


        static void Main(string[] args)
        {
            UserMessageDirector director = new UserMessageDirector();

            SpyMessage authorisation_message = director.GetLogginMessage("admin", "admin");

            Console.WriteLine("Authorisation message:");
            Console.WriteLine(authorisation_message.ToString());

            var desialized_message = SpySerializer.DeserializeMessage(authorisation_message.ToString());
            Console.WriteLine(desialized_message?.ContainToken);

            director.SetToken("secret_token");
            SpyMessage get_victims_message = director.GetVictimsIpListMessage();

            Console.WriteLine("Get victims message:");
            Console.WriteLine(get_victims_message.ToString());

            desialized_message = SpySerializer.DeserializeMessage(get_victims_message.ToString());
            Console.WriteLine(desialized_message?.ContainToken);
        }
    }
}
