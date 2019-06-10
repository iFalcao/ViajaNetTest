using System.ComponentModel.DataAnnotations;

namespace ViajaNet.Domain.DTOs
{
    public class VisitDTO
    {
        public string Url { get; set; }
        public string Browser { get; set; }
        public string Ip { get; set; }
        public string PageParams { get; set; }
    }
}
