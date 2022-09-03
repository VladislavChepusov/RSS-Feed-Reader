using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotecs2.control
{
    [Serializable]
    public partial class XmlReaders
    {
        public string url { get; set;}
        public string update_time { get; set;}
        public XmlReaders() { }
        public XmlReaders (string url, string update_time)
        {
            this.url = url;
            this.update_time = update_time;
        }
    }

}
 
