using System;

namespace Intership.Models.ResponseModels
{
    public class ClientResponseModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public bool AllowEmailNotification { get; set; }
    }
}
