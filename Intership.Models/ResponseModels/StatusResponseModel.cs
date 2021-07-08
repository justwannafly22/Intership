using System;

namespace Intership.Models.ResponseModels
{
    /// <summary>
    /// Status model to response to client
    /// </summary>
    public class StatusResponseModel
    {
        public Guid Id { get; set; }
        public string StatusInfo { get; set; }
    }
}
