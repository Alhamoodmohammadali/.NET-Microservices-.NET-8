namespace Mango.Services.OrderAPI.Models.Dto
{
    public class CartDetailsDto
    {
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        public CartHeaderDto? CartHeader { get; set; }
        public int ProductId { get; set; }
        public CourceDto? Cource { get; set; }
        public int Count { get; set; }
    }
}
