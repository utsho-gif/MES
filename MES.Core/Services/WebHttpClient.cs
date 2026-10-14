using MES.Core.ErrorHandler;
using MES.Core.Logger;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static MES.Core.Enum;

namespace MES.Core.Services
{
    public class WebHttpClient : IWebHttpClient
    {
        private readonly ILoggerUtil _factory;
        private readonly IErrorUtil _errorUtil;
        private static readonly HttpClient _httpClient = new HttpClient();

        public WebHttpClient(ILoggerUtil factory, IErrorUtil errorUtil)
        {
            _factory = factory;
            _errorUtil = errorUtil;
        }

        public async Task<string> PostAsync(string url, string data, string authToken = null)
        {
            var log = _factory.GetLog("WebHttpClient", "PostAsync", data);
            log.Ip = url;

            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = new StringContent(data ?? "", Encoding.UTF8, "application/json");

                if (!string.IsNullOrEmpty(authToken))
                {
                    request.Headers.Add("Authorization", authToken);
                }

                using var response = await _httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    log.Status = "Fail";
                    _errorUtil.AddError(ErrorCode.InternalServerError, log, _factory, responseContent, ((int)response.StatusCode).ToString());
                }
                else
                {
                    log.Status = "Success";
                    log.ResponseModel = responseContent;
                    _factory.WriteLog(log, LogEnum.Information);
                }

                return responseContent;
            }
            catch (Exception ex)
            {
                log.Status = "Fail";
                _factory.WriteErrorLog(log, LogEnum.Error, "PostAsync", "WebHttpClient", ex);
                throw;
            }
        }

        public async Task<string> GetAsync(string url, string authToken = null)
        {
            var log = _factory.GetLog("WebHttpClient", "GetAsync");
            log.Ip = url;

            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, url);

                if (!string.IsNullOrEmpty(authToken))
                {
                    request.Headers.Add("Authorization", authToken);
                }

                using var response = await _httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    log.Status = "Fail";
                    _errorUtil.AddError(ErrorCode.InternalServerError, log, _factory, responseContent, ((int)response.StatusCode).ToString());
                }

                return responseContent;
            }
            catch (Exception ex)
            {
                log.Status = "Fail";
                _factory.WriteErrorLog(log, LogEnum.Error, "GetAsync", "WebHttpClient", ex);
                throw;
            }
        }

        public async Task<string> PutAsync(string url, string data, string authToken = null)
        {
            var log = _factory.GetLog("WebHttpClient", "PutAsync", data);
            log.Ip = url;

            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Put, url);
                request.Content = new StringContent(data ?? "", Encoding.UTF8, "application/json");

                if (!string.IsNullOrEmpty(authToken))
                {
                    request.Headers.Add("Authorization", authToken);
                }

                using var response = await _httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    log.Status = "Fail";
                    _errorUtil.AddError(ErrorCode.InternalServerError, log, _factory, responseContent, ((int)response.StatusCode).ToString());
                }

                return responseContent;
            }
            catch (Exception ex)
            {
                log.Status = "Fail";
                _factory.WriteErrorLog(log, LogEnum.Error, "PutAsync", "WebHttpClient", ex);
                throw;
            }
        }

        public string POST(string url, string data, string authToken = null)
        {
            return PostAsync(url, data, authToken).GetAwaiter().GetResult();
        }

        public string GET(string url, string authToken = null)
        {
            return GetAsync(url, authToken).GetAwaiter().GetResult();
        }
    }
}
