using ServiceManager.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceManager.Contracts
{
    public interface IDataRetreiverService
    {
        /// <summary>
        /// Retreives message objects
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MessageDTO>> RetreiveMessages();

        /// <summary>
        /// Retreives content of file split by new line
        /// </summary>
        /// <returns></returns>
        Task<string[]> RetreiveFileContent();
    }
}
