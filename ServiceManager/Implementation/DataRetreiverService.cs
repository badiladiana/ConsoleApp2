using System.Collections.Generic;
using System.Threading.Tasks;
using DataProvider.Contracts;
using ServiceManager.DataContracts;

namespace ServiceManager.Contracts
{
    public class DataRetreiverService:IDataRetreiverService
    {
        private IDataFileRetreiver fileRetreiver;
        private IMessageParser messageParser;

        public DataRetreiverService(IDataFileRetreiver fileRetreiver, IMessageParser messageParser)
        {
            this.fileRetreiver = fileRetreiver;
            this.messageParser = messageParser;
        }

        public async Task<IEnumerable<MessageDTO>> RetreiveMessages()
        {
            var result = await fileRetreiver.ReadFromFile(null);
            return messageParser.ParseToMessageDTO(result);            
        }

        public async Task<string[]> RetreiveFileContent()
        {
            return await fileRetreiver.ReadFromFile(null);
        }

    }
}
