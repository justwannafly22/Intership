using System;
using System.Collections.Generic;
using System.Text;

namespace Intership.Models.ResponseModels
{
    public class ProductResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
