using ServiceManager.Contracts;
using ServiceManager.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace ServiceManager.Implementation
{
    public class MessageParser : IMessageParser
    {
        public List<MessageDTO> ParseToMessageDTO(string[] messages)
        {
            List<MessageDTO> messageDTOs = new List<MessageDTO>();
            try
            {
                for (int i = 0; i < messages.Length; i++)
                {
                    var lines = messages[0].Split(new[] {Environment.NewLine }, StringSplitOptions.None);
                    var port = TryGetPort(lines);
                    var ip = TryGetIP(lines);
                    var codecs = TryGetCodecs(lines);
                    messageDTOs.Add(new MessageDTO
                    {
                        Codecs = codecs,
                        Port = port,
                        IP = ip
                    });
                }
            }
            catch(Exception ex)
            {
                var message = String.Format("An issue has ocurred while parsing data: {0}", ex.Message);
                ErrorLogUtility.LogError(message, ex.StackTrace);
            }

            return messageDTOs;
        }

        private List<string> TryGetCodecs(string[] lines)
        {
            List<string> codecs = new List<string>();
            try
            {
                foreach (var line in lines)
                {
                    if (line.StartsWith("a="))
                    {
                        var value = line.Split(new[] { "a=" }, StringSplitOptions.None)[1];
                        codecs.Add(value);
                    }
                }

            }
            catch (Exception ex)
            {
                var message = String.Format("An issue has ocurred while parsing Codecs: {0}", ex.Message);
                ErrorLogUtility.LogError(message, ex.StackTrace);
            }

            return codecs;
        }

        private string TryGetIP(string[] lines)
        {
            string ip = null;
            try
            {
                foreach (var line in lines)
                {
                    if (line.StartsWith("c="))
                    {
                        ip = line.Split(new[] { "c=" }, StringSplitOptions.None)[1];
                    }
                }

            }
            catch (Exception ex)
            {
                var message = String.Format("An issue has ocurred while parsing IP: {0}", ex.Message);
                ErrorLogUtility.LogError(message, ex.StackTrace);
            }
            return ip;
        }

        private string TryGetPort(string[] lines)
        {//
            string port = null;
            try
            {
                foreach(var line in lines)
                {
                    if (line.StartsWith("m="))
                    {
                        port = line.Split(new[] { "m=" }, StringSplitOptions.None)[1];
                    }
                }
            }
            catch (Exception ex)
            {
                var message = String.Format("An issue has ocurred while parsing Port: {0}", ex.Message);
                ErrorLogUtility.LogError(message, ex.StackTrace);
            }
            return port;
        }
    }
}
