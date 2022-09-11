using Newtonsoft.Json;
using OAuth2._0.Extensions;
using OAuth2._0.Models;
using System.Net.Http.Headers;
using System.Text;

namespace OAuth2._0.Services
{
    public interface IClientService
    {
        public HttpClient HttpClient { get; }
        Task<ApiResponseModel> GetAsync(string url);
        Task<ApiResponseModel> GetAsync(string url, string token);
        Task<ApiResponseModel> PostWithJsonAsync(string url, object data);
        Task<ApiResponseModel> PostWithFormUrlEncodedAsync(string url, object data);
    }
    public class ClientService : IClientService
    {
        #region Properties

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClientService(IHttpContextAccessor httpContextAccessor, HttpClient httpClient)
        {
            _httpContextAccessor = httpContextAccessor;
            HttpClient = httpClient;
        }

        #endregion

        public HttpClient HttpClient { get; set; }

        public async Task<ApiResponseModel> GetAsync(string url)
        {
            try
            {
                var response = await HttpClient.GetAsync(url);

                return new ApiResponseModel() { StatusCode = response.StatusCode, Data = await response.Content.ReadAsStringAsync() };
            }
            catch (Exception exception)
            {
                return new ApiResponseModel { ErrorFlag = true, Msg = exception.Message, Exception = exception };
            }
        }

        public async Task<ApiResponseModel> GetAsync(string url, string token)
        {
            try
            {
                HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                var response = await HttpClient.GetAsync(url);

                return new ApiResponseModel() { StatusCode = response.StatusCode, Data = await response.Content.ReadAsStringAsync() };
            }
            catch (Exception exception)
            {
                return new ApiResponseModel { ErrorFlag = true, Msg = exception.Message, Exception = exception };
            }
        }

        public async Task<ApiResponseModel> PostWithJsonAsync(string url, object data)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(data);
                var jsonContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var response = await HttpClient.PostAsync(url, jsonContent);

                return new ApiResponseModel() { StatusCode = response.StatusCode, Data = await response.Content.ReadAsStringAsync() };
            }
            catch (Exception exception)
            {
                return new ApiResponseModel { ErrorFlag = true, Msg = exception.Message, Exception = exception };
            }
        }

        public async Task<ApiResponseModel> PostWithFormUrlEncodedAsync(string url, object data)
        {
            try
            {
                var keyValues = data.ToKeyValue();
                var content = new FormUrlEncodedContent(keyValues);
                var response = await HttpClient.PostAsync(url, content);

                return new ApiResponseModel() { StatusCode = response.StatusCode, Data = await response.Content.ReadAsStringAsync() };
            }
            catch (Exception exception)
            {
                return new ApiResponseModel { ErrorFlag = true, Msg = exception.Message, Exception = exception };
            }
        }
    }
}
