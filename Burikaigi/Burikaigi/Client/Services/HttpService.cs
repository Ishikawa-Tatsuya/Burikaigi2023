using Sotsera.Blazor.Toaster;
using System.Net.Http.Json;

namespace Burikaigi.Client.Services
{
    public class HttpService
    {
        readonly HttpClient _http;
        readonly IToaster _toaster;
        readonly LoadingService _loadingService;

        public HttpService(
            HttpClient http,
            IToaster toaster,
            LoadingService loadingService
        )
        {
            _http = http;
            _toaster = toaster;
            _loadingService = loadingService;
        }

        public async Task<TValue?> GetFromJsonAsync<TValue>(string url) where TValue : class
        {
            _loadingService.Loading = true;
            try
            {
                var httpResponse = await _http.GetAsync(url);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.NoContent) return null;
                if (httpResponse.Content.Headers?.ContentType?.MediaType == "text/plain")
                {
                    await CheckResponse(httpResponse);
                    return null;
                }
                return await httpResponse.Content.ReadFromJsonAsync<TValue>();
            }
            catch
            {
                _toaster.Error("Invalid Communication");
                return null;
            }
            finally
            {
                _loadingService.Loading = false;
            }
        }

        public async Task<bool> PostAsJsonAsync<TValue>(string url, TValue data)
        {
            _loadingService.Loading = true;
            try
            {
                var response = await _http.PostAsJsonAsync(url, data);
                return await CheckResponse(response);
            }
            finally
            {
                _loadingService.Loading = false;
            }
        }

        public async Task<bool> DeleteAsync(string requestUri)
        {
            _loadingService.Loading = true;
            try
            {
                var response = await _http.DeleteAsync(requestUri);
                return await CheckResponse(response);
            }
            finally
            {
                _loadingService.Loading = false;
            }
        }

        async Task<bool> CheckResponse(HttpResponseMessage? response)
        {
            if (response == null) throw new ArgumentNullException(nameof(response));

            if (response.Content.Headers?.ContentType?.MediaType == "text/plain")
            {
                var error = await response.Content.ReadAsStringAsync();

                if (error == null) error = "Invalid communication";

                _toaster.Error(error);
                return false;
            }
            return true;
        }
    }
}
