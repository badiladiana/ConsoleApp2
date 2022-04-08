using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager.DataContracts
{
    public class MessageDTO
    {
        public string IP { get; set; }

        public string Port { get; set; }

        public IEnumerable<string> Codecs { get; set; }
    }
}
