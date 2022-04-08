using System.Threading.Tasks;

namespace DataProvider.Contracts
{
    public interface IDataFileRetreiver
    {
        /// <summary>
        /// Reads text from file  based on given path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<string[]> ReadFromFile(string path);
    }
}
