namespace Mango.Services.OrderAPI.Models.Dto
{
    public class CourceDto
    {
        public int CourceId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string VideoURl { get; set; }
        public string? VideoLocalPath { get; set; }
        public IFormFile Video { get; set; }


    }
}
