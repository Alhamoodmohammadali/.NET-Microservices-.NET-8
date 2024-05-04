namespace Mango.Services.OrderAPI.Models.Dto
{
    public class OrderDetailsDto
    {
        public int OrderDetailsId { get; set; }
        public int OrderHeaderId { get; set; }
        public int ProductId { get; set; }
        public CourceDto? Cource { get; set; }
        public int Count { get; set; }
        public string CourceName { get; set; }
        public double Price { get; set; }
    }
}
