using System;

namespace Intership.DTO.Client
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
    }
}
