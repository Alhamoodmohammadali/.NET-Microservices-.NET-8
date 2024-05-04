using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EduSpot.Services.SubscriptionCardAPI.Models.Dto;
namespace EduSpot.Services.SubscriptionCardAPI.Models
{
    public class CartDetails
    {
        [Key]
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        [ForeignKey("CartHeaderId")]
        public CartHeader CartHeader { get; set; }
        public int CourseId { get; set; }
        [NotMapped]
        public CourceDto Product { get; set; }
        public int Count { get; set; }
    }
}
