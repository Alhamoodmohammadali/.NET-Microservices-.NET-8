
using static EduSpot.Web.Utility.SD;

namespace EduSpot.Web.Models
{
    public class RequestDto
    {
        public ApiType apitype { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
        public ContentType ContentType { get; set; } = ContentType.Json;

    }
}
