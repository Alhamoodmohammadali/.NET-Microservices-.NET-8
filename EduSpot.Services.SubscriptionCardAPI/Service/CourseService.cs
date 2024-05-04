using EduSpot.Services.SubscriptionCardAPI.Models.Dto;
using EduSpot.Services.SubscriptionCardAPI.Service.IService;
using Newtonsoft.Json;
namespace EduSpot.Services.SubscriptionCardAPI.Service
{
    public class CourseService : ICourseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CourseService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
        public async Task<IEnumerable<CourceDto>> GetCourses()
        {
            var client = _httpClientFactory.CreateClient("Courses");
            var response = await client.GetAsync($"/api/Courses");
            var apiContet = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContet);
            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<CourceDto>>(Convert.ToString(resp.Result));
            }
            return new List<CourceDto>();
        }
    }
}