using Newtonsoft.Json;

namespace Intership.LoggerService.ErrorModel
{
    public class BaseResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public BaseResponseModel(string message, int code)
        {
            StatusCode = code;
            Message = message;
        }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}