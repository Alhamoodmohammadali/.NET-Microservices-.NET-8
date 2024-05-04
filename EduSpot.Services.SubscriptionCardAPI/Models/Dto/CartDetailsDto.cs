﻿namespace EduSpot.Services.SubscriptionCardAPI.Models.Dto
{
    public class CartDetailsDto
    {
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        public CartHeaderDto? CartHeader { get; set; }
        public int CoursId { get; set; }
        public CourceDto? Course { get; set; }
        public int Count { get; set; }
    }
}
