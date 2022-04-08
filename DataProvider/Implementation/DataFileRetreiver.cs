using System;
using System.IO;
using System.Threading.Tasks;
using DataProvider.Contracts;
using Utility;

namespace DataProvider.Implementation
{
    public class DataFileRetreiver : IDataFileRetreiver
    {
        public async Task<string[]> ReadFromFile(string path)
        {
            //hardcoded path for now
            path = @"C:\Exercise\sdp_input.txt";
            try
            {
                byte[] result;

                using (FileStream SourceStream = File.Open(path, FileMode.Open))
                {
                    result = new byte[SourceStream.Length];                    
                    await SourceStream.ReadAsync(result, 0, (int)SourceStream.Length);
                }
                string text = System.Text.Encoding.ASCII.GetString(result);
                string[] lines = text.Split(new[] { "\r\n\r\n" }, StringSplitOptions.None);
                return lines;
            }
            catch (Exception ex)
            {
                var message = String.Format("An Issue has ocurred while reading data: {0}", ex.Message);
                ErrorLogUtility.LogError(message, ex.StackTrace);
            }
            return null;
        }
    }
}
