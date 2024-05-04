using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Mango.Services.OrderAPI.Models.Dto;

namespace Mango.Services.OrderAPI.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }
        public int OrderHeaderId { get; set; }
        [ForeignKey("OrderHeaderId")]
        public OrderHeader? OrderHeader { get; set; }
        public int ProductId { get; set; }
        [NotMapped]
        public CourceDto? Cource { get; set; }
        public int Count { get; set; }
        public string CourceName { get; set; }
        public double Price { get; set; }
    }
}
