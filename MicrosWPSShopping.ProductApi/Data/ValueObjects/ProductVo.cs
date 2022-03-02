﻿namespace MicrosWPSShopping.ProductApi.Data.ValueObjects
{
    public class ProductVo
    {
        public long Id { get; set; }
        public string name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
