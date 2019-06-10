using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViajaNet.Domain.Models
{
    [Serializable]
    public class Visit
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Browser { get; set; }
        public string Ip { get; set; }
        public string PageParams { get; set; }
    }
}
