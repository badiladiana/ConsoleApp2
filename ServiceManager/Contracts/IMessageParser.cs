using ServiceManager.DataContracts;
using System.Collections.Generic;

namespace ServiceManager.Contracts
{
    public interface IMessageParser
    {
        /// <summary>
        /// Parses the data
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        List<MessageDTO> ParseToMessageDTO(string[] lines);//
    }
}
