﻿using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models
{
    public class Basket : BaseEntity<int>, IAuditable
    {
        public int UserId { get; set; }
        public User? User { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<BasketProduct>? BasketProducts { get; set; }
    }
}
