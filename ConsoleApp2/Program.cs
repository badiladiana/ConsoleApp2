using DataProvider.Contracts;
using DataProvider.Implementation;
using ServiceManager.Contracts;
using ServiceManager.Implementation;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IDataFileRetreiver fileRetreiver = new DataFileRetreiver();
            IMessageParser messageParser = new MessageParser();
            var dataRetreiver = new DataRetreiverService(fileRetreiver, messageParser);
            var messages = await  dataRetreiver.RetreiveFileContent();
            System.Collections.Generic.IEnumerable<ServiceManager.DataContracts.MessageDTO> result = await dataRetreiver.RetreiveMessages();

            foreach(var message in messages)
            {
                System.Console.WriteLine(message);
                System.Console.WriteLine("--------------------------");
            }            
        }
    }
}
