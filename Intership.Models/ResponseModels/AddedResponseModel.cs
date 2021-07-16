using System;
using System.Net;

namespace Intership.Models.ResponseModels
{
    public class AddedResponseModel : BaseResponseModel
    {
        public Guid Id { get; set; }

        public AddedResponseModel(Guid id)
        {
            Id = id;
        }

        public AddedResponseModel(Guid id, HttpStatusCode code)
        {
            Id = id;
            StatusCode = code;
        }
    }
}
