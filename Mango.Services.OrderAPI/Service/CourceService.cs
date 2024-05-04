using Mango.Services.OrderAPI.Models.Dto;
using Mango.Services.OrderAPI.Service.IService;
using Newtonsoft.Json;

namespace Mango.Services.OrderAPI.Service
{
    public class CourceService : ICourceService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public CourceService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
        public async Task<IEnumerable<CourceDto>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient("Cource");
            var response = await client.GetAsync($"/api/Cource");
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
