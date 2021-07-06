using System;

namespace Intership.Models.ResponseModels
{
    /// <summary>
    /// Product model to response to client
    /// </summary>
    public class ProductResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
