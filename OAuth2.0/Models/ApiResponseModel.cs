using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace OAuth2._0.Models
{
    public class ApiResponseModel : BaseModel
    {
        public override string ModelName => nameof(ApiResponseModel);
        public string Data { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
